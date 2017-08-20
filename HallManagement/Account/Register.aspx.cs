using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using HallManagement.Models;
using AspNet.Identity.MySQL;
using System.Collections.Generic;
using System.Data;

namespace HallManagement.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setPageLayout();
                logInSecurity();
                clearAllField();
                loadDropdownList();
                sMessage.Visible = false;
                eMessage.Visible = false;
            }
        }

        protected void clearAllField()
        {
            firstName.Text = "";
            lastName.Text = "";
            designation.Text = "";
            position.Text = "";
            fathersName.Text = "";
            mothersName.Text = "";
            Sex.SelectedValue = "Male";
            birthdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            studentid.Text = "";
            batch.Text = "";
            applicationNo.Text = "";
            userName.Text = "";
            Email.Text = "";
            PhoneNumber.Text = "";
            Address.Text = "";
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
            ddlDiscipline.DataSource = dt2;
            ddlDiscipline.DataTextField = "disciplineName";
            ddlDiscipline.DataValueField = "disciplineId";
            ddlDiscipline.DataBind();
        }

        protected void logInSecurity()
        {
            if (User.IsInRole("HallAuthority"))
            {
                divAdmin.Visible = false;
                ddlRegisterAs.SelectedValue = "1";
                divHallAuthority.Visible = false;
                divStudent.Visible = true;
                divCommon.Visible = true;
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

        protected void setPageLayout()
        {
            if (ddlRegisterAs.SelectedValue == "2")
            {
                divAdmin.Visible = true;
                divHallAuthority.Visible = true;
                divCommon.Visible = true;
                divStudent.Visible = false;
            }
            else if (ddlRegisterAs.SelectedValue == "1")
            {
                divAdmin.Visible = true;
                divStudent.Visible = true;
                divCommon.Visible = true;
                divHallAuthority.Visible = false;
            }
            else
            {
                divAdmin.Visible = true;
                divStudent.Visible = false;
                divHallAuthority.Visible = false;
                divCommon.Visible = false;
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (ddlRegisterAs.SelectedValue == "1")
                {
                    var isValidRoll = new MySQLDatabase().QueryValue("countRollNo", new Dictionary<string, object>()
                    {
                        {"@roll",studentid.Text }
                    }, true).ToString();
                    int r = int.Parse(isValidRoll);

                    var isValidEmail = new MySQLDatabase().QueryValue("countRegisterEmail", new Dictionary<string, object>()
                    {
                        {"@email",Email.Text }
                    }, true).ToString();
                    int v = int.Parse(isValidEmail);

                    var isValidApplicationNo = new MySQLDatabase().QueryValue("countApplicationNo", new Dictionary<string, object>()
                    {
                        {"@aid",applicationNo.Text }
                    }, true).ToString();
                    int aNo = int.Parse(isValidApplicationNo);

                    var isValidApplication = new MySQLDatabase().QueryValue("countStudentApplication", new Dictionary<string, object>()
                    {
                        {"@aid",applicationNo.Text }
                    }, true).ToString();
                    int sa = int.Parse(isValidApplication);

                    var hallStud = new MySQLDatabase().QueryValue("countHallStudentByHId", new Dictionary<string, object>()
                    {
                        {"@hid",ddlHall.SelectedValue }
                    }, true).ToString();
                    int hallStudent = int.Parse(hallStud);

                    var hallSeat = new MySQLDatabase().QueryValue("getHallTotalSeat", new Dictionary<string, object>()
                    {
                        {"@hid",ddlHall.SelectedValue }
                    }, true).ToString();
                    int hallTotalSeat = int.Parse(hallSeat);

                    bool isCreated = true;
                    if (v == 0 && aNo != 0 && sa == 0 && r == 0 && hallStudent < hallTotalSeat)
                    {
                        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        var user = new ApplicationUser()
                        {
                            UserName = userName.Text,
                            Email = Email.Text,
                            FirstName = firstName.Text,
                            LastName = lastName.Text,
                            FathersName = fathersName.Text,
                            MothersName = mothersName.Text,
                            Birthdate = DateTime.Parse(birthdate.Text),
                            Address = Address.Text,
                            Sex = Sex.SelectedValue,
                            PhoneNumber = PhoneNumber.Text
                        };
                        IdentityResult result = manager.Create(user, Password.Text);
                        if (result.Succeeded)
                        {
                            var res = manager.AddToRole(user.Id, "Student");
                            new MySQLDatabase().Execute("addStudent",
                                new Dictionary<string, object>()
                                {
                                    {"@uid",user.Id },
                                    {"@hid",ddlHall.SelectedValue },
                                    {"@aid",int.Parse(applicationNo.Text) },
                                    {"@did",ddlDiscipline.SelectedValue },
                                    {"@roll",studentid.Text },
                                    {"@batch",batch.Text },
                                    {"@rid",ddlRoomNo.SelectedValue}
                                }, true);

                        }
                        else
                        {
                            isCreated = false;
                            eMessage.InnerText = "Failed to create an account";
                            sMessage.Visible = false;
                            eMessage.Visible = true;
                        }
                        if (isCreated)
                        {
                            clearAllField();
                            loadDropdownList();
                            sMessage.InnerText = "Account has been created";
                            eMessage.Visible = false;
                            sMessage.Visible = true;
                        }
                    }
                    else
                    {
                        eMessage.InnerText = "Failed to create an account";
                        sMessage.Visible = false;
                        eMessage.Visible = true;
                    }
                }
                else if (ddlRegisterAs.SelectedValue == "2")
                {
                    var isValidEmail = new MySQLDatabase().QueryValue("countRegisterEmail", new Dictionary<string, object>()
                    {
                        {"@email",Email.Text }
                    }, true).ToString();
                    int v = int.Parse(isValidEmail);
                    bool isCreated = true;
                    if (v == 0)
                    {
                        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        var user = new ApplicationUser()
                        {
                            UserName = userName.Text,
                            Email = Email.Text,
                            FirstName = firstName.Text,
                            LastName = lastName.Text,
                            FathersName = fathersName.Text,
                            MothersName = mothersName.Text,
                            Birthdate = DateTime.Parse(birthdate.Text),
                            Address = Address.Text,
                            Sex = Sex.SelectedValue,
                            PhoneNumber = PhoneNumber.Text
                        };
                        IdentityResult result = manager.Create(user, Password.Text);
                        if (result.Succeeded)
                        {
                            var res = manager.AddToRole(user.Id, "HallAuthority");
                            new MySQLDatabase().Execute("addHallAuthority",
                                new Dictionary<string, object>()
                                {
                                    {"@uid",user.Id },
                                    {"@hid",ddlHall.SelectedValue },
                                    {"@designation",designation.Text },
                                    {"@position",position.Text }
                                }, true);
                        }
                        else
                        {
                            isCreated = false;
                            eMessage.InnerText = "Failed to create an account";
                            sMessage.Visible = false;
                            eMessage.Visible = true;
                        
                        }
                        if (isCreated)
                        {
                            clearAllField();
                            loadDropdownList();
                            sMessage.InnerText = "Account has been created";
                            eMessage.Visible = false;
                            sMessage.Visible = true;
                        }
                    }
                    else
                    {
                        eMessage.InnerText = "Failed to create an account";
                        sMessage.Visible = false;
                        eMessage.Visible = true;
                    }

                }
                else
                {
                    var isValidEmail = new MySQLDatabase().QueryValue("countRegisterEmail", new Dictionary<string, object>()
                    {
                        {"@email",Email.Text }
                    }, true).ToString();
                    int v = int.Parse(isValidEmail);
                    bool isCreated = true;
                    if (v == 0)
                    {
                        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                        var user = new ApplicationUser()
                        {
                            UserName = userName.Text,
                            Email = Email.Text,
                            FirstName = firstName.Text,
                            LastName = lastName.Text,
                            FathersName = fathersName.Text,
                            MothersName = mothersName.Text,
                            Birthdate = DateTime.Parse(birthdate.Text),
                            Address = Address.Text,
                            Sex = Sex.SelectedValue,
                            PhoneNumber = PhoneNumber.Text
                        };
                        IdentityResult result = manager.Create(user, Password.Text);
                        if (result.Succeeded)
                        {
                            var res = manager.AddToRole(user.Id, "Admin");
                        }
                        else
                        {
                            isCreated = false;
                            eMessage.InnerText = "Failed to create an account";
                            sMessage.Visible = false;
                            eMessage.Visible = true;
                        }
                        if (isCreated)
                        {
                            clearAllField();
                            loadDropdownList();
                            sMessage.InnerText = "Account has been created";
                            eMessage.Visible = false;
                            sMessage.Visible = true;
                        }
                    }
                    else
                    {
                        eMessage.InnerText = "Failed to create an account";
                        sMessage.Visible = false;
                        eMessage.Visible = true;
                    }
                }

            }
            else
            {
                eMessage.InnerText = "Failed to create an account";
                sMessage.Visible = false;
                eMessage.Visible = true;
                
            }

        }

        protected void ddlRegisterAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPageLayout();
        }

        protected void ddlHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRoomDisciplineDDL();
        }
    }
}