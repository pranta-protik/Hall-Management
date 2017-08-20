using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Common
{
    public partial class EditApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                loadApplicationDetails();
                loadDropdownList();
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

        protected void loadApplicationDetails()
        {
            if (Request.QueryString["AId"] != null)
            {
                var res = new MySQLDatabase().Query("getApplicationDetailsByAId", new Dictionary<string, object>()
                {
                    {"@aid",Request.QueryString["AId"] }
                }, true);

                var res2 = res.Select(x => new
                {
                    AppId = x["id"],
                    FName = x["FirstName"],
                    LName = x["LastName"],
                    RollNo = x["rollNo"],
                    LTCGPA = x["lastTermCGPA"],
                    DisciplineId = x["disciplineId"],
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
                    HallId = x["hallId"],
                    Email = x["Email"],
                    PreAddress = x["presentAddress"],
                    PerAddress = x["permanentAddress"],
                    LGName = x["localGuardianName"],
                    LGAddress = x["localGuardianAddress"],
                    LGPhoneNo = x["localGuardianPhoneNo"],
                    PhoneNo = x["PhoneNumber"]
                }).ToList();

                foreach (var res3 in res2)
                {
                    applicationId.InnerText = res3.AppId;
                    firstName.Text = res3.FName;
                    lastName.Text = res3.LName;
                    studentid.Text = res3.RollNo;
                    ltCGPA.Text = res3.LTCGPA;
                    ddlDiscipline.SelectedValue = res3.DisciplineId;
                    fathersName.Text = res3.FatherName;
                    fathersOccupation.Text = res3.FatherOccupation;
                    fathersYearlyIncome.Text = res3.FatherYearlyIncome;
                    mothersName.Text = res3.MotherName;
                    mothersOccupation.Text = res3.MotherOccupation;
                    mothersYearlyIncome.Text = res3.MotherYearlyIncome;
                    batch.Text = res3.Batch;
                    birthdate.Text = Convert.ToDateTime(res3.Birthdate).ToString("yyyy-MM-dd");
                    Sex.SelectedValue = res3.Sex;
                    bloodGroup.Text = res3.BGroup;
                    maritalStatus.SelectedValue = res3.MStatus;
                    causesOfApplication.Text = res3.CausesOfApplication;
                    ddlHall.SelectedValue = res3.HallId;
                    Email.Text = res3.Email;
                    presentAddress.Text = res3.PreAddress;
                    permanentAddress.Text = res3.PerAddress;
                    localGuardianName.Text = res3.LGName;
                    localGuardianAddress.Text = res3.LGAddress;
                    localGuardianPhoneNo.Text = res3.LGPhoneNo;
                    PhoneNumber.Text = res3.PhoneNo;
                }
            }
        }

        protected void loadDropdownList()
        {
            //Loading All Hall
            var res2 = new MySQLDatabase().Query("getAllHall", new Dictionary<string, object>(), true);
            ddlHall.DataSource = res2.Select(x => new
            {
                Text = x["hallName"],
                Value = x["id"]
            }).ToList();
            ddlHall.DataTextField = "Text";
            ddlHall.DataValueField = "Value";
            ddlHall.DataBind();

            loadDisciplineDDL();

        }

        protected void loadDisciplineDDL()
        {
            //Loading All Discipline
            var res = new MySQLDatabase().Query("getAllDiscipline", new Dictionary<string, object>()
            {
                {"@hid",ddlHall.SelectedValue }
            }, true);
            ddlDiscipline.DataSource = res.Select(x => new
            {
                Text = x["disciplineName"],
                Value = x["id"]
            }).ToList();
            ddlDiscipline.DataTextField = "Text";
            ddlDiscipline.DataValueField = "Value";
            ddlDiscipline.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (Request.QueryString["AId"] != null)
                {
                    var isValidRoll = new MySQLDatabase().QueryValue("countEditApplicationRollNo", new Dictionary<string, object>()
                {
                    {"@roll",studentid.Text },
                    {"@aid",Request.QueryString["AId"] }
                }, true).ToString();

                    int r = int.Parse(isValidRoll);

                    var isValidEmail = new MySQLDatabase().QueryValue("countEditApplicationEmail", new Dictionary<string, object>()
                {
                    {"@email",Email.Text },
                    {"@aid",Request.QueryString["AId"] }
                }, true).ToString();
                    int v = int.Parse(isValidEmail);

                    if (v == 0 && r == 0)
                    {
                        var res = new MySQLDatabase().Execute("updateApplicationInfo", new Dictionary<string, object>()
                    {
                        {"@aid",Request.QueryString["AId"] },
                        {"@firstName",firstName.Text },
                        {"@lastName",lastName.Text },
                        {"@roll",studentid.Text },
                        {"@ltCGPA",ltCGPA.Text },
                        {"@did",ddlDiscipline.SelectedValue },
                        {"@fathersName",fathersName.Text },
                        {"@fathersOccupation",fathersOccupation.Text },
                        {"@fathersYearlyIncome",fathersYearlyIncome.Text },
                        {"@mothersName",mothersName.Text },
                        {"@mothersOccupation",mothersOccupation.Text },
                        {"@mothersYearlyIncome",mothersYearlyIncome.Text },
                        {"@batch",batch.Text },
                        {"@birthdate",DateTime.Parse(birthdate.Text) },
                        {"@sex",Sex.SelectedValue },
                        {"@bloodGroup",bloodGroup.Text },
                        {"@maritalStatus",maritalStatus.Text },
                        {"@causesOfApplication",causesOfApplication.Text },
                        {"@hid",ddlHall.SelectedValue },
                        {"@email",Email.Text },
                        {"@preAddress",presentAddress.Text },
                        {"@perAddress",permanentAddress.Text },
                        {"@localGuardianName",localGuardianName.Text},
                        {"@localGuardianAddress",localGuardianAddress.Text },
                        {"@localGuardianPhoneNo",localGuardianPhoneNo.Text },
                        {"@phoneNo",PhoneNumber.Text }
                    }, true);

                        sMessage.InnerText = "Application has been updated";
                        eMessage.Visible = false;
                        sMessage.Visible = true;
                    }
                    else
                    {
                        eMessage.InnerText = "Application update failed";
                        sMessage.Visible = false;
                        eMessage.Visible = true;
                    }
                }
                else
                {
                    eMessage.InnerText = "Application update failed";
                    sMessage.Visible = false;
                    eMessage.Visible = true;
                }
            }
        }

        protected void ddlHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDisciplineDDL();
        }

        protected void clearAllField()
        {
            applicationId.InnerText = "";
            firstName.Text = "";
            lastName.Text = "";
            studentid.Text = "";
            ltCGPA.Text = "";
            fathersName.Text = "";
            fathersOccupation.Text = "";
            fathersYearlyIncome.Text = "";
            mothersName.Text = "";
            mothersOccupation.Text = "";
            mothersYearlyIncome.Text = "";
            batch.Text = "";
            birthdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            bloodGroup.Text = "";
            causesOfApplication.Text = "";
            Email.Text = "";
            presentAddress.Text = "";
            permanentAddress.Text = "";
            localGuardianName.Text = "";
            localGuardianAddress.Text = "";
            localGuardianPhoneNo.Text = "";
            PhoneNumber.Text = "";
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            if (Request.QueryString["AId"] != null)
            {
                var uId="";
                try
                {
                    uId = new MySQLDatabase().QueryValue("getUIdByAId", new Dictionary<string, object>()
                    {
                        {"@aid",Request.QueryString["AId"] }
                    }, true).ToString();

                    new MySQLDatabase().Execute("deleteUserByUId", new Dictionary<string, object>()
                    {
                        {"@uid",uId }
                    }, true);
                }
                catch (Exception)
                {
                    
                }

                new MySQLDatabase().Execute("deleteApplicationByAId", new Dictionary<string, object>()
                {
                    {"@aid",Request.QueryString["AId"] }
                }, true);
                clearAllField();
                sMessage.InnerText = "Application has been deleted";
                eMessage.Visible = false;
                sMessage.Visible = true;
            }
            else
            {
                eMessage.InnerText = "Application can not be deleted";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }

        }
    }
}