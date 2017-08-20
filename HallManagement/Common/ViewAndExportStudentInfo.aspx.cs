using AspNet.Identity.MySQL;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HallManagement.Common
{
    public partial class ViewAndExportStudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
                ddlViewBy.SelectedValue = "All";
                loadHADiv();
                loadGVByAll();
                sMessage.Visible = false;
                eMessage.Visible = false;
            }
        }

        protected void loadHADiv()
        {
            if (User.IsInRole("Admin"))
            {
                divHAAccount.Visible = true;
            }
            else if (User.IsInRole("HallAuthority"))
            {
                divHAAccount.Visible = false;
            }
            else if (User.IsInRole("Student"))
            {
                divHAAccount.Visible = false;
            }
            else
            {
                divHAAccount.Visible = false;
            }
        }

        protected void logInSecurity()
        {
            if (User.IsInRole("Admin"))
            {

            }
            else if (User.IsInRole("HallAuthority"))

            {
            }
            else if (User.IsInRole("Student"))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void loadGVByAll()
        {
            var student = new MySQLDatabase().Query("getAllStudentDetail", new Dictionary<string, object>(), true);
            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void ddlViewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlViewBy.SelectedValue == "All")
            {
                gvAllStudent.Visible = true;
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
                loadGVByAll();
            }
            else if (ddlViewBy.SelectedValue == "Range")
            {
                gvAllStudent.Visible = true;
                divViewByRange.Visible = true;
                divViewByAppId.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
                ddlRange.SelectedValue = "50";
                loadGVByRange50();
            }
            else if (ddlViewBy.SelectedValue == "ApplicationNo")
            {
                gvAllStudent.Visible = false;
                txtApplicationId.Text = "";
                divViewByAppId.Visible = true;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
            }

            else if (ddlViewBy.SelectedValue == "Hall")
            {
                gvAllStudent.Visible = true;
                divViewByHall.Visible = true;
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
                loadDDLHall();
                loadGVByHall();
            }
            else if (ddlViewBy.SelectedValue == "Discipline")
            {
                gvAllStudent.Visible = true;
                divViewByHall.Visible = false;
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = true;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
                loadDDLDisciplineHall1();
                loadDDLDisciplineHall2();
                loadGVByHallDiscipline();

            }
            else if (ddlViewBy.SelectedValue == "RoomNo")
            {
                gvAllStudent.Visible = true;
                txtRoomNo.Text = "";
                divViewByHall.Visible = false;
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = true;
                divViewByUserName.Visible = false;
                loadDDLRoomHall();
                loadGVByRoomHall();
            }
            else if (ddlViewBy.SelectedValue == "UserName")
            {
                gvAllStudent.Visible = false;
                txtUName.Text = "";
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = true;
            }
            else if (ddlViewBy.SelectedValue == "Name")
            {
                gvAllStudent.Visible = false;
                txtName.Text = "";
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = true;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
            }
            else if (ddlViewBy.SelectedValue == "BloodGroup")
            {
                gvAllStudent.Visible = false;
                txtBGroup.Text = "";
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = true;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
            }
            else if (ddlViewBy.SelectedValue == "RollNo")
            {
                gvAllStudent.Visible = false;
                txtRollNo.Text = "";
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = true;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
            }
            else if (ddlViewBy.SelectedValue == "Batch")
            {
                gvAllStudent.Visible = true;
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = true;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
                loadDDLBatch();
                loadGVByBatch();

            }
            else if (ddlViewBy.SelectedValue == "PhoneNo")
            {
                gvAllStudent.Visible = false;
                txtPhoneNo.Text = "";
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = true;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
            }
            else if (ddlViewBy.SelectedValue == "Address")
            {
                gvAllStudent.Visible = false;
                txtAddress.Text = "";
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = true;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
                divViewByUserName.Visible = false;
            }

        }

        protected void loadDDLBatch()
        {
            var Batch = new MySQLDatabase().Query("getAllDistinctBatch", new Dictionary<string, object>(), true);
            var batchName = Batch.Select(x => new
            {
                Batch = x["batch"]
            }).ToList();
            ddlBatch.DataSource = batchName;
            ddlBatch.DataTextField = "Batch";
            ddlBatch.DataValueField = "Batch";
            ddlBatch.DataBind();
        }

        protected void loadGVByUName()
        {
            var student = new MySQLDatabase().Query("getStudentByUName", new Dictionary<string, object>()
            {
                {"@UName",txtUName.Text }
            }, true);
            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByRollNo()
        {
            var student = new MySQLDatabase().Query("getStudentByRollNo", new Dictionary<string, object>()
            {
                {"@rollNo",txtRollNo.Text }
            }, true);
            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByAddress()
        {
            var student = new MySQLDatabase().Query("getStudentByAddress", new Dictionary<string, object>()
            {
                {"@address",'%'+txtAddress.Text+'%' }
            }, true);
            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByBGroup()
        {
            var bGroup = new MySQLDatabase().Query("getStudentByBGroup", new Dictionary<string, object>()
            {
                {"@BGroup",txtBGroup.Text }
            }, true);
            var bGroup2 = bGroup.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = bGroup2;
            gvAllStudent.DataBind();
        }

        protected void loadGVByPhoneNo()
        {
            var phone = new MySQLDatabase().Query("getStudentByPhoneNo", new Dictionary<string, object>()
            {
                {"@phoneNo",'%'+txtPhoneNo.Text }
            }, true);
            var phoneNo = phone.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = phoneNo;
            gvAllStudent.DataBind();
        }

        protected void loadGVByName()
        {
            var name = new MySQLDatabase().Query("getStudentByName", new Dictionary<string, object>()
            {
                {"@name",txtName.Text+'%' }
            }, true);
            var name2 = name.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = name2;
            gvAllStudent.DataBind();
        }

        protected void loadGVByApplicationNo()
        {
            var student = new MySQLDatabase().Query("getStudentByAId", new Dictionary<string, object>()
            {
                {"@aid",txtApplicationId.Text }
            }, true);
            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByRange50()
        {
            var student = new MySQLDatabase().Query("getStudentByRange50", new Dictionary<string, object>(), true);
            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByRange100()
        {
            var student = new MySQLDatabase().Query("getStudentByRange100", new Dictionary<string, object>(), true);
            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByRange150()
        {
            var student = new MySQLDatabase().Query("getStudentByRange150", new Dictionary<string, object>(), true);
            var studentDetail = student.Select(x => new
            {

                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByRange200()
        {
            var student = new MySQLDatabase().Query("getStudentByRange200", new Dictionary<string, object>(), true);
            var studentDetail = student.Select(x => new
            {

                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByBatch()
        {
            var student = new MySQLDatabase().Query("getStudentByBatch", new Dictionary<string, object>()
            {
                {"@batch",ddlBatch.SelectedValue }
            }, true);
            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByHallDiscipline()
        {
            var student = new MySQLDatabase().Query("getStudentByHallDiscipline", new Dictionary<string, object>()
            {
                {"@HName",ddlDisciplineHall1.SelectedValue },
                {"@DName",ddlDisciplineHall2.SelectedValue }
            }, true);

            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByRoomHall()
        {
            var student = new MySQLDatabase().Query("getStudentByRoomHall", new Dictionary<string, object>()
            {
                {"@HName",ddlRoomHall.SelectedValue },
                {"@roomNo",txtRoomNo.Text}
            }, true);

            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadGVByHall()
        {
            var student = new MySQLDatabase().Query("getStudentByHall", new Dictionary<string, object>()
            {
                {"@HName",ddlHall.SelectedValue }
            }, true);
            var studentDetail = student.Select(x => new
            {
                StudUId = x["studUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                ApplicationNo = x["applicationId"],
                RollNo = x["rollNo"],
                Batch = x["batch"],
                Hall = x["hallName"],
                Discipline = x["disciplineName"],
                RoomNo = x["roomNo"],
                BGroup = x["bloodGroup"]
            }).ToList();

            gvAllStudent.DataSource = studentDetail;
            gvAllStudent.DataBind();
        }

        protected void loadDDLHall()
        {
            var HName = new MySQLDatabase().Query("getAllHallName", new Dictionary<string, object>(), true);
            var hallName = HName.Select(x => new
            {
                HallName = x["hallName"]
            }).ToList();
            ddlHall.DataSource = hallName;
            ddlHall.DataTextField = "HallName";
            ddlHall.DataValueField = "HallName";
            ddlHall.DataBind();
        }

        protected void loadDDLRoomHall()
        {
            var HName = new MySQLDatabase().Query("getAllHallName", new Dictionary<string, object>(), true);
            var hallName = HName.Select(x => new
            {
                HallName = x["hallName"]
            }).ToList();
            ddlRoomHall.DataSource = hallName;
            ddlRoomHall.DataTextField = "HallName";
            ddlRoomHall.DataValueField = "HallName";
            ddlRoomHall.DataBind();
        }

        protected void loadDDLDisciplineHall1()
        {
            var HName = new MySQLDatabase().Query("getAllHallName", new Dictionary<string, object>(), true);
            var hallName = HName.Select(x => new
            {
                HallName = x["hallName"]
            }).ToList();
            ddlDisciplineHall1.DataSource = hallName;
            ddlDisciplineHall1.DataTextField = "HallName";
            ddlDisciplineHall1.DataValueField = "HallName";
            ddlDisciplineHall1.DataBind();
        }

        protected void loadDDLDisciplineHall2()
        {
            var DName = new MySQLDatabase().Query("getAllDisciplineNameByHallName", new Dictionary<string, object>()
            {
                {"@HName",ddlDisciplineHall1.SelectedValue }
            }, true);
            var disciplineName = DName.Select(x => new
            {
                DisciplineName = x["disciplineName"]
            }).ToList();
            ddlDisciplineHall2.DataSource = disciplineName;
            ddlDisciplineHall2.DataTextField = "DisciplineName";
            ddlDisciplineHall2.DataValueField = "DisciplineName";
            ddlDisciplineHall2.DataBind();
        }

        protected void ddlRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRange.SelectedValue == "50")
            {
                gvAllStudent.Visible = true;
                loadGVByRange50();
                divViewByAppId.Visible = false;
                divViewByRange.Visible = true;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
            }
            else if (ddlRange.SelectedValue == "100")
            {
                gvAllStudent.Visible = true;
                loadGVByRange100();
                divViewByAppId.Visible = false;
                divViewByRange.Visible = true;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
            }
            else if (ddlRange.SelectedValue == "150")
            {
                gvAllStudent.Visible = true;
                loadGVByRange150();
                divViewByAppId.Visible = false;
                divViewByRange.Visible = true;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
            }
            else if (ddlRange.SelectedValue == "200")
            {
                gvAllStudent.Visible = true;
                loadGVByRange200();
                divViewByAppId.Visible = false;
                divViewByRange.Visible = true;
                divViewByHall.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = false;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByRoomNo.Visible = false;
            }
        }

        protected void ddlHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGVByHall();
        }

        protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGVByBatch();
        }

        protected void ddlDisciplineHall1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDDLDisciplineHall2();
            loadGVByHallDiscipline();
        }

        protected void ddlDisciplineHall2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGVByHallDiscipline();
        }

        protected void btnSearchRNo_ServerClick(object sender, EventArgs e)
        {
            loadGVByRollNo();
            gvAllStudent.Visible = true;
        }

        protected void btnSearchAId_ServerClick(object sender, EventArgs e)
        {
            loadGVByApplicationNo();
            gvAllStudent.Visible = true;
        }

        protected void btnSearchAddress_ServerClick(object sender, EventArgs e)
        {
            if (txtAddress.Text != "")
            {
                loadGVByAddress();
                gvAllStudent.Visible = true;
            }
            else
            {
                gvAllStudent.Visible = false;
            }
        }

        protected void btnName_ServerClick(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                loadGVByName();
                gvAllStudent.Visible = true;
            }
            else
            {
                gvAllStudent.Visible = false;
            }
        }

        protected void btnBGroup_ServerClick(object sender, EventArgs e)
        {
            loadGVByBGroup();
            gvAllStudent.Visible = true;
        }

        protected void btnPhoneNo_ServerClick(object sender, EventArgs e)
        {
            if (txtPhoneNo.Text != "")
            {
                loadGVByPhoneNo();
                gvAllStudent.Visible = true;
            }
            else
            {
                gvAllStudent.Visible = false;
            }
        }

        protected void ddlRoomHall_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnRoomNo_ServerClick(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "")
            {
                loadGVByRoomHall();
                gvAllStudent.Visible = true;
            }
            else
            {
                gvAllStudent.Visible = false;
            }
        }

        protected void btnUName_ServerClick(object sender, EventArgs e)
        {
            if (txtUName.Text != "")
            {
                loadGVByUName();
                gvAllStudent.Visible = true;
            }
            else
            {
                gvAllStudent.Visible = false;
            }
        }

        protected void lnkHallAuthorityInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ViewAndExportHAInfo.aspx");
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }


        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Student.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvAllStudent.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A0, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
                gvAllStudent.AllowPaging = true;
                gvAllStudent.DataBind();
            }
            catch (Exception)
            {
                eMessage.InnerText = "No Page Found";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }
    }
}