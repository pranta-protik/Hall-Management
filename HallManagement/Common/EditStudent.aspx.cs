using AspNet.Identity.MySQL;
using HallManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Common
{
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                loadStudentDetails();
                loadDropdownList();
                divHall.Visible = true;
                divChangeHall.Visible = false;
                divRoom.Visible = true;
                divDiscipline.Visible = true;
                divRoomChange.Visible = false;
                divDisciplineChange.Visible = false;
                sMessage.Visible = false;
                eMessage.Visible = false;
            }
        }

        protected void loadStudentDetails()
        {
            var userId = Request.QueryString["SUId"];
            var registerInfo = new MySQLDatabase().Query("getRegistrationInfoByUId", new Dictionary<string, object>()
            {
                {"@uid",userId }
            }, true);

            var regInfo = registerInfo.Select(x => new
            {
                UName = x["UserName"],
                ApplicationId = x["applicationId"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                HallId = x["hallId"],
                Email = x["Email"],
                Address = x["Address"],
                PhoneNo = x["PhoneNumber"],
                RoomNo = x["roomNo"]

            }).ToList();

            foreach (var res in regInfo)
            {
                firstName.Text = res.FName;
                lastName.Text = res.LName;
                fathersName.Text = res.FatherName;
                mothersName.Text = res.MotherName;
                Sex.SelectedValue = res.Sex;
                birthdate.Text = Convert.ToDateTime(res.Birthdate).ToString("yyyy-MM-dd");
                ddlHall.SelectedValue = res.HallId;
                discipline.Text = res.Discipline;
                studentid.Text = res.RollNo;
                roomNo.Text = res.RoomNo;
                userName.Text = res.UName;
                batch.Text = res.Batch;
                applicationNo.Text = res.ApplicationId;
                Email.Text = res.Email;
                PhoneNumber.Text = res.PhoneNo;
                Address.Text = res.Address;

            }

        }

        protected void loadDropdownList()
        {
            //Load All Hall
            var res2 = new MySQLDatabase().Query("getAllHall", new Dictionary<string, object>(), true);
            ddlHall.DataSource = res2.Select(x => new
            {
                Text = x["hallName"],
                Value = x["id"]
            }).ToList();
            ddlHall.DataTextField = "Text";
            ddlHall.DataValueField = "Value";
            ddlHall.DataBind();

            loadRoomDisciplineDDL();
        }

        protected void loadRoomDisciplineDDL()
        {
            //Load Available Room
            var room = new MySQLDatabase().Query("getSIdAndSRoomIdByHId", new Dictionary<string, object>()
            {
                { "@hid",ddlHall.SelectedValue }
            }, true);
            var room2 = room.Select(x => new
            {
                SId = x["sId"],
                SRoomId = x["sRoomId"]
            }).ToList();

            var distRoom = new MySQLDatabase().Query("getDistinctRoomId", new Dictionary<string, object>()
            {
                {"@hid",ddlHall.SelectedValue }
            }, true);
            var distRoomId = distRoom.Select(x => new
            {
                DistRId = x["distRoomId"]
            }).ToList();

            DataTable dt = new DataTable("loadRoomDDL");
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.AllowDBNull = false;
            column.ColumnName = "roomId";
            dt.Columns.Add(column);
            DataColumn column2 = new DataColumn();
            column2.DataType = System.Type.GetType("System.String");
            column2.AllowDBNull = false;
            column2.ColumnName = "roomNo";
            dt.Columns.Add(column2);
            DataRow row;

            foreach (var dRoomId in distRoomId)
            {
                var roomTotalSeat = new MySQLDatabase().QueryValue("getRoomTotalSeatByHRId", new Dictionary<string, object>()
                {
                    {"@hid",ddlHall.SelectedValue },
                    {"@rid",Convert.ToInt32(dRoomId.DistRId) }
                }, true).ToString();
                int roomTotalSeatNo = int.Parse(roomTotalSeat);

                var countStudentSeat = new MySQLDatabase().QueryValue("countStudentSeatByHRId", new Dictionary<string, object>()
                {
                    {"@hid",ddlHall.SelectedValue},
                    {"@rid",Convert.ToInt32(dRoomId.DistRId) }
                }, true).ToString();
                int countStudSeat = int.Parse(countStudentSeat);

                if (countStudSeat < roomTotalSeatNo)
                {
                    var roomNo = new MySQLDatabase().QueryValue("getRoomNoByHRId", new Dictionary<string, object>()
                    {
                        {"@hid",ddlHall.SelectedValue },
                        {"rid",Convert.ToInt32(dRoomId.DistRId) }
                    }, true).ToString();

                    row = dt.NewRow();
                    row["roomId"] = Convert.ToInt32(dRoomId.DistRId);
                    row["roomNo"] = roomNo;
                    dt.Rows.Add(row);
                }
            }
            ddlRoomNo.DataSource = dt;
            ddlRoomNo.DataTextField = "roomNo";
            ddlRoomNo.DataValueField = "roomId";
            ddlRoomNo.DataBind();

            //Load available discipline
            var discipline = new MySQLDatabase().Query("getSIdAndDisciplineIdByHId", new Dictionary<string, object>()
            {
                {"@hid",ddlHall.SelectedValue }
            }, true);
            var discipline2 = discipline.Select(x => new
            {
                SId = x["sId"],
                SDisciplineId = x["sDisciplineId"]
            }).ToList();

            var distDiscipline = new MySQLDatabase().Query("getDistinctDisciplineId", new Dictionary<string, object>()
            {
                {"@hid",ddlHall.SelectedValue }
            }, true);
            var distDisciplineId = distDiscipline.Select(x => new
            {
                DistDId = x["distDisciplineId"]
            }).ToList();

            DataTable dt2 = new DataTable("loadDisciplineDDL");
            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Int32");
            col.AllowDBNull = false;
            col.ColumnName = "disciplineId";
            dt2.Columns.Add(col);
            DataColumn col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.String");
            col2.AllowDBNull = false;
            col2.ColumnName = "disciplineName";
            dt2.Columns.Add(col2);
            DataRow row2;

            foreach (var dDisciplineId in distDisciplineId)
            {
                var disciplineTotalSeat = new MySQLDatabase().QueryValue("getDisciplineTotalSeatByHDId", new Dictionary<string, object>()
                {
                    {"@hid",ddlHall.SelectedValue },
                    {"@did",Convert.ToInt32(dDisciplineId.DistDId) }
                }, true).ToString();
                int disciplineTotalSeatNo = int.Parse(disciplineTotalSeat);

                var StudentSeat = new MySQLDatabase().QueryValue("countStudentSeatByHDId", new Dictionary<string, object>()
                {
                    {"@hid",ddlHall.SelectedValue},
                    {"@did",Convert.ToInt32(dDisciplineId.DistDId) }
                }, true).ToString();
                int StudSeat = int.Parse(StudentSeat);

                if (StudSeat < disciplineTotalSeatNo)
                {
                    var disciplineName = new MySQLDatabase().QueryValue("getDisciplineByHDId", new Dictionary<string, object>()
                    {
                        {"@hid",ddlHall.SelectedValue },
                        {"did",Convert.ToInt32(dDisciplineId.DistDId) }
                    }, true).ToString();

                    row2 = dt2.NewRow();
                    row2["disciplineId"] = Convert.ToInt32(dDisciplineId.DistDId);
                    row2["disciplineName"] = disciplineName;
                    dt2.Rows.Add(row2);
                }
            }
            try
            {
                ddlDiscipline.DataSource = dt2;
                ddlDiscipline.DataTextField = "disciplineName";
                ddlDiscipline.DataValueField = "disciplineId";
                ddlDiscipline.DataBind();
            }
            catch (Exception)
            {
                eMessage2.InnerText = "Seat unavailable for this discipline";
            }
        }

        protected void logInSecurity()
        {
            if (User.IsInRole("HallAuthority"))
            {

            }
            else if (User.IsInRole("Student"))
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


        protected void UpdateUser_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var isValidRoll = new MySQLDatabase().QueryValue("countEditRollNo", new Dictionary<string, object>()
                    {
                        {"@roll",studentid.Text },
                        {"@uid",Request.QueryString["SUId"] }
                    }, true).ToString();
                int r = int.Parse(isValidRoll);

                var isValidEmail = new MySQLDatabase().QueryValue("countManageEmail", new Dictionary<string, object>()
                    {
                        {"@email",Email.Text },
                        {"@uid",Request.QueryString["SUId"] }
                    }, true).ToString();
                int v = int.Parse(isValidEmail);

                var isValidApplicationNo = new MySQLDatabase().QueryValue("countApplicationNo", new Dictionary<string, object>()
                    {
                        {"@aid",applicationNo.Text }
                    }, true).ToString();
                int aNo = int.Parse(isValidApplicationNo);

                var isValidApplication = new MySQLDatabase().QueryValue("countEditStudentApplication", new Dictionary<string, object>()
                    {
                        {"@aid",applicationNo.Text },
                        {"@uid",Request.QueryString["SUId"] }
                    }, true).ToString();
                int sa = int.Parse(isValidApplication);

                if (v == 0 && aNo != 0 && sa == 0 && r == 0)
                {
                    new MySQLDatabase().Execute("updateStudentInfo", new Dictionary<string, object>()
                    {
                        {"@uid",Request.QueryString["SUId"] },
                        {"@firstName",firstName.Text },
                        {"@lastName",lastName.Text },
                        {"@fatherName",fathersName.Text },
                        {"@motherName",mothersName.Text },
                        {"@sex",Sex.SelectedValue },
                        {"@birthdate",Convert.ToDateTime(birthdate.Text) },
                        {"@roll",studentid.Text },
                        {"@batch",batch.Text },
                        {"@applicationNo",applicationNo.Text },
                        {"@email",Email.Text },
                        {"@phoneNo",PhoneNumber.Text },
                        {"@address",Address.Text }
                    }, true);

                    sMessage.InnerText = "Account updated successfully";
                    eMessage.Visible = false;
                    sMessage.Visible = true;
                }
                else
                {
                    eMessage.InnerText = "Failed to update account";
                    sMessage.Visible = false;
                    eMessage.Visible = true;
                }
            }
            else
            {
                eMessage.InnerText = "Failed to update account";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }

        protected void ddlHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRoomDisciplineDDL();
        }

        protected void btnChangeInfo_Click(object sender, EventArgs e)
        {
            divHall.Visible = false;
            divRoom.Visible = false;
            divDiscipline.Visible = false;
            divChangeHall.Visible = true;
            divRoomChange.Visible = true;
            divDisciplineChange.Visible = true;
        }

        protected void btnCancelInfo_Click(object sender, EventArgs e)
        {
            divHall.Visible = true;
            divRoom.Visible = true;
            divDiscipline.Visible = true;
            divChangeHall.Visible = false;
            divRoomChange.Visible = false;
            divDisciplineChange.Visible = false;
        }

        protected void clearAllField()
        {
            firstName.Text = "";
            lastName.Text = "";
            fathersName.Text = "";
            mothersName.Text = "";
            birthdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            discipline.Text = "";
            studentid.Text = "";
            roomNo.Text = "";
            userName.Text = "";
            batch.Text = "";
            applicationNo.Text = "";
            Email.Text = "";
            PhoneNumber.Text = "";
            Address.Text = "";
        }

        protected void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var hallStud = new MySQLDatabase().QueryValue("countEditHallStudentByHUId", new Dictionary<string, object>()
                    {
                        {"@hid",ddlHall.SelectedValue },
                        {"@uid",Request.QueryString["SUId"] }
                    }, true).ToString();
                int hallStudent = int.Parse(hallStud);

                var hallSeat = new MySQLDatabase().QueryValue("getHallTotalSeat", new Dictionary<string, object>()
                    {
                        {"@hid",ddlHall.SelectedValue }
                    }, true).ToString();
                int hallTotalSeat = int.Parse(hallSeat);

                if (hallStudent < hallTotalSeat)
                {
                    new MySQLDatabase().Execute("updateStudentInfo2", new Dictionary<string, object>()
                    {
                        {"@uid",Request.QueryString["SUId"] },
                        {"@hid",ddlHall.SelectedValue },
                        {"@did",ddlDiscipline.SelectedValue },
                        {"@rid",ddlRoomNo.SelectedValue }
                    }, true);
                    Response.Redirect(Request.Url.AbsoluteUri);
                    sMessage.InnerText = "Account updated successfully";
                    eMessage.Visible = false;
                    sMessage.Visible = true;
                }
                else
                {
                    eMessage.InnerText = "Failed to update account";
                    sMessage.Visible = false;
                    eMessage.Visible = true;
                }
            }
            else
            {
                eMessage.InnerText = "Failed to update account";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            if (Request.QueryString["SUId"] != null)
            {
                new MySQLDatabase().Execute("deleteStudentBySUId", new Dictionary<string, object>()
                {
                    {"@uid",Request.QueryString["SUId"] }
                }, true);
                clearAllField();
                sMessage.InnerText = "Student account has been deleted";
                eMessage.Visible = false;
                eMessage2.Visible = false;
                sMessage.Visible = true;
            }
            else
            {
                eMessage.InnerText = "Student account can not be deleted";
                sMessage.Visible = false;
                eMessage2.Visible = false;
                eMessage.Visible = true;
            }
        }
    }
}