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
    public partial class ViewAndExportApplication : System.Web.UI.Page
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
                ddlViewBy.SelectedValue = "All";
                loadGVByAll();
                sMessage.Visible = false;
                eMessage.Visible = false;
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
            var appDetail = new MySQLDatabase().Query("getAllApplicationDetail", new Dictionary<string, object>(), true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void ddlViewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlViewBy.SelectedValue == "All")
            {
                gvAllApplication.Visible = true;
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
                loadGVByAll();
            }
            else if (ddlViewBy.SelectedValue == "Accepted")
            {
                gvAllApplication.Visible = true;
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
                loadGVByAccepted();
            }
            else if (ddlViewBy.SelectedValue == "Unaccepted")
            {
                gvAllApplication.Visible = true;
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
                loadGVByUnaccepted();
            }
            else if (ddlViewBy.SelectedValue == "Latest")
            {
                gvAllApplication.Visible = true;
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
                loadGVByLatest();
            }
            else if (ddlViewBy.SelectedValue == "Range")
            {
                gvAllApplication.Visible = true;
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
                ddlRange.SelectedValue = "50";
                loadGVByRange50();
            }
            else if (ddlViewBy.SelectedValue == "ApplicationNo")
            {
                gvAllApplication.Visible = false;
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
            }

            else if (ddlViewBy.SelectedValue == "Hall")
            {
                gvAllApplication.Visible = true;
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
                loadDDLHall();
                loadGVByHall();
            }
            else if (ddlViewBy.SelectedValue == "Discipline")
            {
                gvAllApplication.Visible = true;
                divViewByHall.Visible = false;
                divViewByAppId.Visible = false;
                divViewByRange.Visible = false;
                divViewByBatch.Visible = false;
                divViewByAddress.Visible = false;
                divViewByDiscipline.Visible = true; ;
                divViewByRollNo.Visible = false;
                divViewByName.Visible = false;
                divViewByBloodGroup.Visible = false;
                divViewByPhoneNo.Visible = false;
                loadDDLDisciplineHall1();
                loadDDLDisciplineHall2();
                loadGVByHallDiscipline();

            }
            else if (ddlViewBy.SelectedValue == "Name")
            {
                gvAllApplication.Visible = false;
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
            }
            else if (ddlViewBy.SelectedValue == "BloodGroup")
            {
                gvAllApplication.Visible = false;
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
            }
            else if (ddlViewBy.SelectedValue == "RollNo")
            {
                gvAllApplication.Visible = false;
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
            }
            else if (ddlViewBy.SelectedValue == "Batch")
            {
                gvAllApplication.Visible = true;
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
                loadDDLBatch();
                loadGVByBatch();

            }
            else if (ddlViewBy.SelectedValue == "PhoneNo")
            {
                gvAllApplication.Visible = false;
                txtAddress.Text = "";
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
            }
            else if (ddlViewBy.SelectedValue == "Address")
            {
                gvAllApplication.Visible = false;
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
            }

        }

        protected void loadDDLBatch()
        {
            var Batch = new MySQLDatabase().Query("getAllBatchName", new Dictionary<string, object>(), true);
            var batchName = Batch.Select(x => new
            {
                Batch = x["batch"]
            }).ToList();
            ddlBatch.DataSource = batchName;
            ddlBatch.DataTextField = "Batch";
            ddlBatch.DataValueField = "Batch";
            ddlBatch.DataBind();
        }

        protected void loadGVByAccepted()
        {
            var appDetail = new MySQLDatabase().Query("getAcceptedApplicationDetail", new Dictionary<string, object>(), true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByUnaccepted()
        {
            var appDetail = new MySQLDatabase().Query("getUnacceptedApplicationDetail", new Dictionary<string, object>(), true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByLatest()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByDesc", new Dictionary<string, object>(), true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByRollNo()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByRollNo", new Dictionary<string, object>()
            {
                {"@rollNo",txtRollNo.Text }
            }, true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByAddress()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByAddress", new Dictionary<string, object>()
            {
                {"@address",'%'+txtAddress.Text+'%' }
            }, true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByBGroup()
        {
            var bGroup = new MySQLDatabase().Query("getApplicationByBGroup", new Dictionary<string, object>()
            {
                {"@BGroup",txtBGroup.Text }
            }, true);
            var bGroup2 = bGroup.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = bGroup2;
            gvAllApplication.DataBind();
        }

        protected void loadGVByPhoneNo()
        {
            var phone = new MySQLDatabase().Query("getApplicationByPhoneNo", new Dictionary<string, object>()
            {
                {"@phoneNo",'%'+txtPhoneNo.Text }
            }, true);
            var phoneNo = phone.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = phoneNo;
            gvAllApplication.DataBind();
        }

        protected void loadGVByName()
        {
            var name = new MySQLDatabase().Query("getApplicationByName", new Dictionary<string, object>()
            {
                {"@name",txtName.Text+'%' }
            }, true);
            var name2 = name.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = name2;
            gvAllApplication.DataBind();
        }

        protected void loadGVByApplicationNo()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByAId", new Dictionary<string, object>()
            {
                {"@aid",txtApplicationId.Text }
            }, true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByRange50()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByRange50", new Dictionary<string, object>(), true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByRange100()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByRange100", new Dictionary<string, object>(), true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByRange150()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByRange150", new Dictionary<string, object>(), true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByRange200()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByRange200", new Dictionary<string, object>(), true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByBatch()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByBatch", new Dictionary<string, object>()
            {
                {"@batch",ddlBatch.SelectedValue }
            }, true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByHallDiscipline()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByHallDiscipline", new Dictionary<string, object>()
            {
                {"@HName",ddlDisciplineHall1.SelectedValue },
                {"@DName",ddlDisciplineHall2.SelectedValue }
            }, true);

            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
        }

        protected void loadGVByHall()
        {
            var appDetail = new MySQLDatabase().Query("getApplicationByHall", new Dictionary<string, object>()
            {
                {"@HName",ddlHall.SelectedValue }
            }, true);
            var applicationDetail = appDetail.Select(x => new
            {
                ApplicationNo = x["id"],
                FName = x["FirstName"],
                LName = x["LastName"],
                RollNo = x["rollNo"],
                LTCGPA = x["lastTermCGPA"],
                Discipline = x["disciplineName"],
                FatherName = x["fathersName"],
                FatherOccupation = x["fathersOccupation"],
                FatherYearlyIncome = x["fathersYearlyIncome"],
                MotherName = x["mothersName"],
                MotherOccupation = x["mothersOccupation"],
                MotherYearlyIncome = x["mothersYearlyIncome"],
                Batch = x["batch"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                BGroup = x["bloodGroup"],
                MStatus = x["maritalStatus"],
                CausesOfApplication = x["causesOfApplication"],
                Hall = x["hallName"],
                Email = x["Email"],
                PreAddress = x["presentAddress"],
                PerAddress = x["permanentAddress"],
                LGName = x["localGuardianName"],
                LGAddress = x["localGuardianAddress"],
                LGPhoneNo = x["localGuardianPhoneNo"],
                PhoneNo = x["PhoneNumber"]
            }).ToList();

            gvAllApplication.DataSource = applicationDetail;
            gvAllApplication.DataBind();
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
                gvAllApplication.Visible = true;
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
            }
            else if (ddlRange.SelectedValue == "100")
            {
                gvAllApplication.Visible = true;
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
            }
            else if (ddlRange.SelectedValue == "150")
            {
                gvAllApplication.Visible = true;
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
            }
            else if (ddlRange.SelectedValue == "200")
            {
                gvAllApplication.Visible = true;
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
            gvAllApplication.Visible = true;
        }

        protected void btnSearchAId_ServerClick(object sender, EventArgs e)
        {
            loadGVByApplicationNo();
            gvAllApplication.Visible = true;
        }

        protected void btnSearchAddress_ServerClick(object sender, EventArgs e)
        {
            if (txtAddress.Text != "")
            {
                loadGVByAddress();
                gvAllApplication.Visible = true;
            }
            else
            {
                gvAllApplication.Visible = false;
            }
        }

        protected void btnName_ServerClick(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                loadGVByName();
                gvAllApplication.Visible = true;
            }
            else
            {
                gvAllApplication.Visible = false;
            }
        }

        protected void btnBGroup_ServerClick(object sender, EventArgs e)
        {
            loadGVByBGroup();
            gvAllApplication.Visible = true;
        }

        protected void btnPhoneNo_ServerClick(object sender, EventArgs e)
        {
            if (txtPhoneNo.Text != "")
            {
                loadGVByPhoneNo();
                gvAllApplication.Visible = true;
            }
            else
            {
                gvAllApplication.Visible = false;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }


        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Application.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvAllApplication.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A0, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
                gvAllApplication.AllowPaging = true;
                gvAllApplication.DataBind();
            }
            catch (Exception)
            {
                eMessage.InnerText = "No page found";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }
    }
}