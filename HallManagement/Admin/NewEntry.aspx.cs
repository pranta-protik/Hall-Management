using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Admin
{
    public partial class NewEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                clearAllField();
                loadDropdownList();
                loadGridView();
                unAllotedCount();
                sMessage1.Visible = false;
                sMessage2.Visible = false;
                sMessage3.Visible = false;
                eMessage1.Visible = false;
                eMessage2.Visible = false;
                eMessage3.Visible = false;
            }
        }

        protected void clearAllField()
        {
            hallName.Text = "";
            totalRoom.Text = "";
            totalSeat.Text = "";
            roomNo.Text = "";
            roomAllotedSeat.Text = "";
            discipline.Text = "";
            disciplineAllotedSeat.Text = "";
        }

        protected void logInSecurity()
        {
            if (User.IsInRole("Student"))
            {
                Response.Redirect("~/Default.aspx");
            }
            else if (User.IsInRole("HallAuthority"))
            {
                Response.Redirect("~/Default.aspx");
            }
            else if (User.IsInRole("Admin"))
            {

            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void unAllotedCount()
        {
            var hall = new MySQLDatabase().QueryValue("getNumberOfHall", new Dictionary<string, object>(), true).ToString();
            int numberOfHall = Convert.ToInt32(hall);
            if (numberOfHall > 0)
            {
                var hallTotalSeat = new MySQLDatabase().QueryValue("getHallTotalSeat", new Dictionary<string, object>()
                {
                    {"@hid",ddlHallDiscipline.SelectedValue}
                }, true).ToString();

                var unallottedDSeat = new MySQLDatabase().QueryValue("countDisciplineUnallotedSeatByHId", new Dictionary<string, object>()
                {
                    {"@hid",ddlHallDiscipline.SelectedValue }
                }, true).ToString();
                lblUnallottedDisciplineSeat.Text = "Unallotted Seat: " + ((unallottedDSeat == "") ? hallTotalSeat : unallottedDSeat);

                var hallTotalSeat2 = new MySQLDatabase().QueryValue("getHallTotalSeat", new Dictionary<string, object>()
                {
                    {"@hid",ddlHallRoom.SelectedValue }
                }, true).ToString();

                var unallottedRSeat = new MySQLDatabase().QueryValue("countRoomUnallottedSeatByHId", new Dictionary<string, object>()
                {
                    {"@hid",ddlHallRoom.SelectedValue }
                }, true).ToString();
                lblUnallottedRoomSeat.Text = "Unalloted Seat: " + ((unallottedRSeat == "") ? hallTotalSeat2 : unallottedRSeat);
            }
        }

        protected void loadGridView()
        {
            var hallInfo = new MySQLDatabase().Query("getAllHallInfo", new Dictionary<string, object>(), true);
            var allHallInfo = hallInfo.Select(x => new
            {
                HId = x["id"],
                HName = x["hallName"],
                TRoomNo = x["totalRoomNo"],
                TSeatNo = x["totalSeatNo"]
            }).ToList();
            gvHallRoom.DataSource = allHallInfo;
            gvHallRoom.DataBind();

            var roomInfo = new MySQLDatabase().Query("getAllRoomInfoByHId", new Dictionary<string, object>()
            {
                {"@hid",ddlHallRoom.SelectedValue }
            }, true);
            var allRoomInfo = roomInfo.Select(x => new
            {
                RId = x["id"],
                HName = x["hallName"],
                RoomNo = x["roomNo"],
                SeatNo = x["seatNumber"]
            }).ToList();
            gvRoomSeat.DataSource = allRoomInfo;
            gvRoomSeat.DataBind();

            var disciplineInfo = new MySQLDatabase().Query("getAllDisciplineInfoByHId", new Dictionary<string, object>()
            {
                {"@hid",ddlHallDiscipline.SelectedValue }
            }, true);
            var allDisciplineInfo = disciplineInfo.Select(x => new
            {
                DId = x["id"],
                HName = x["hallName"],
                DName = x["disciplineName"],
                AllotedSeat = x["allotedSeatNo"]
            }).ToList();
            gvDisciplineSeat.DataSource = allDisciplineInfo;
            gvDisciplineSeat.DataBind();
        }

        protected void loadDropdownList()
        {
            //Room Seat Entry Portion
            var res = new MySQLDatabase().Query("getAllHall", new Dictionary<string, object>(), true);
            ddlHallRoom.DataSource = res.Select(x => new
            {
                Text = x["hallName"],
                Value = x["id"]
            }).ToList();
            ddlHallRoom.DataTextField = "Text";
            ddlHallRoom.DataValueField = "Value";
            ddlHallRoom.DataBind();

            //Discipline Seat Entry Portion
            var res2 = new MySQLDatabase().Query("getAllHall", new Dictionary<string, object>(), true);
            ddlHallDiscipline.DataSource = res2.Select(x => new
            {
                Text = x["hallName"],
                Value = x["id"]
            }).ToList();
            ddlHallDiscipline.DataTextField = "Text";
            ddlHallDiscipline.DataValueField = "Value";
            ddlHallDiscipline.DataBind();
        }

        protected void alloteHallRoom_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var hall = new MySQLDatabase().QueryValue("countHallName", new Dictionary<string, object>()
                {
                    {"@hName",hallName.Text}
                }, true).ToString();
                int h = int.Parse(hall);
                if (h == 0)
                {
                    new MySQLDatabase().Execute("addHallRoom", new Dictionary<string, object>()
                    {
                        {"@hName",hallName.Text },
                        {"@totalRoomNo",totalRoom.Text },
                        {"@totalSeatNo",totalSeat.Text }
                    }, true);
                    sMessage1.InnerText = "Room has been alloted successfully";
                    eMessage1.Visible = false;
                    sMessage1.Visible = true;
                    loadDropdownList();
                    unAllotedCount();
                    loadGridView();
                    clearAllField();
                }
                else
                {
                    eMessage1.InnerText = "Room allotement failed";
                    sMessage1.Visible = false;
                    eMessage1.Visible = true;
                }

            }
            else
            {
                eMessage1.InnerText = "Room allotement failed";
                sMessage1.Visible = false;
                eMessage1.Visible = true;
            }
        }

        protected void alloteDisciplineSeat_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var disc = new MySQLDatabase().QueryValue("countDiscipline", new Dictionary<string, object>() {
                    {"@dName",discipline.Text },
                    {"@hid",ddlHallDiscipline.SelectedValue }
                }, true).ToString();
                int d = int.Parse(disc);

                var totalSeat = new MySQLDatabase().Query("getTotalSeatAndDisciplineAllotedSeat", new Dictionary<string, object>()
                {
                    {"@hid",ddlHallDiscipline.SelectedValue }
                }, true);
                var res = totalSeat.Select(x => new
                {
                    TotalSeat = x["totalSeatNo"],
                    DisciplineTotalSeat = x["disciplineTotalSeat"]
                }).ToList();
                int t = 0;
                int dt = 0;
                foreach (var res2 in res)
                {
                    if (res2.TotalSeat != null)
                    {
                        t = int.Parse(res2.TotalSeat);
                    }
                    if (res2.DisciplineTotalSeat != null)
                    {
                        dt = int.Parse(res2.DisciplineTotalSeat);
                    }
                }
                int das = int.Parse(disciplineAllotedSeat.Text);
                if (d == 0 && (dt + das) <= t)
                {
                    new MySQLDatabase().Execute("addDisciplineAllotedSeat", new Dictionary<string, object>()
                    {
                        {"@hid",ddlHallDiscipline.SelectedValue },
                        {"@disciplineName",discipline.Text },
                        {"@allotedSeat",disciplineAllotedSeat.Text}
                    }, true);
                    sMessage3.InnerText = "Seat has been alloted successfully";
                    eMessage3.Visible = false;
                    sMessage3.Visible = true;
                    unAllotedCount();
                    loadGridView();
                    clearAllField();
                }
                else
                {
                    eMessage3.InnerText = "Seat allotment failed";
                    sMessage3.Visible = false;
                    eMessage3.Visible = true;
                }

            }
            else
            {
                eMessage3.InnerText = "Seat allotment failed";
                sMessage3.Visible = false;
                eMessage3.Visible = true;
            }
        }

        protected void alloteRoomSeat_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var room = new MySQLDatabase().QueryValue("countRoomNo", new Dictionary<string, object>()
                {
                    {"@rNo",roomNo.Text },
                    {"@hid",ddlHallRoom.SelectedValue }
                }, true).ToString();
                int r = int.Parse(room);
                var checkTotalSeat = new MySQLDatabase().Query("getTotalSeatAndRoomAllotedSeat", new Dictionary<string, object>()
                {
                    {"@hid",ddlHallRoom.SelectedValue}
                }, true);
                var res = checkTotalSeat.Select(x => new
                {
                    TotalSeat = x["totalSeatNo"],
                    RoomTotalSeat = x["roomTotalSeat"]
                }).ToList();
                int t = 0;
                int rt = 0;
                foreach (var res2 in res)
                {
                    if (res2.TotalSeat != null)
                    {
                        t = int.Parse(res2.TotalSeat);
                    }
                    if (res2.RoomTotalSeat != null)
                    {
                        rt = int.Parse(res2.RoomTotalSeat);
                    }
                }
                int ras = int.Parse(roomAllotedSeat.Text);
                if (r == 0 && (rt + ras) <= t)
                {
                    new MySQLDatabase().Execute("addRoomSeat", new Dictionary<string, object>()
                    {
                        {"@hid",ddlHallRoom.SelectedValue },
                        {"@roomNo",roomNo.Text },
                        {"@seatNumber",roomAllotedSeat.Text }
                    }, true);
                    sMessage2.InnerText = "Seat has been alloted successfully";
                    eMessage2.Visible = false;
                    sMessage2.Visible = true;
                    unAllotedCount();
                    loadGridView();
                    clearAllField();
                }
                else
                {
                    eMessage2.InnerText = "Seat allotment failed";
                    sMessage2.Visible = false;
                    eMessage2.Visible = true;
                }

            }
            else
            {
                eMessage2.InnerText = "Seat allotment failed";
                sMessage2.Visible = false;
                eMessage2.Visible = true;
            }
        }

        protected void ddlHallRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            unAllotedCount();
            loadGridView();
        }

        protected void ddlHallDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            unAllotedCount();
            loadGridView();
        }

        protected void lnkDeleteHall_Click(object sender, EventArgs e)
        {
            LinkButton lnkHall = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkHall.NamingContainer;
            HiddenField hfHallId = (HiddenField)row.FindControl("hfHallId");

            new MySQLDatabase().Execute("deleteHallByHId", new Dictionary<string, object>()
            {
                {"@hid",hfHallId.Value }
            }, true);
            loadDropdownList();
            unAllotedCount();
            loadGridView();
        }

        protected void lnkDeleteRoom_Click(object sender, EventArgs e)
        {
            LinkButton lnkRoom = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkRoom.NamingContainer;
            HiddenField hfRoomId = (HiddenField)row.FindControl("hfRoomId");

            new MySQLDatabase().Execute("deleteRoomByRId", new Dictionary<string, object>()
            {
                {"@rid",hfRoomId.Value }
            }, true);
            unAllotedCount();
            loadGridView();
        }

        protected void lnkDeleteDiscipline_Click(object sender, EventArgs e)
        {
            LinkButton lnkDiscipline = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkDiscipline.NamingContainer;
            HiddenField hfDisciplineId = (HiddenField)row.FindControl("hfDisciplineId");

            new MySQLDatabase().Execute("deleteDisciplineByDId", new Dictionary<string, object>()
            {
                {"@did",hfDisciplineId.Value }
            }, true);
            unAllotedCount();
            loadGridView();
        }
    }
}