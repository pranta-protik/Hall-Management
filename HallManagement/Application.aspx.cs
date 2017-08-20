using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement
{
    public partial class Applicaion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                loadApplicationId();
                loadDropdownList();
                clearAllField();
                sMessage.Visible = false;
                eMessage.Visible = false;
            }
        }

        protected void loadApplicationId()
        {
            var aId = new MySQLDatabase().QueryValue("getCurrentApplicationId", new Dictionary<string, object>(), true).ToString();
            if (aId == "")
            {
                applicationId.InnerText = "1";
            }
            else
            {
                applicationId.InnerText = aId;
            }
        }

        protected void clearAllField()
        {
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
            Sex.SelectedValue = "Male";
            maritalStatus.SelectedValue = "Unmarried";
            causesOfApplication.Text = "";
            bloodGroup.Text = "";
            Email.Text = "";
            presentAddress.Text = "";
            permanentAddress.Text = "";
            localGuardianName.Text = "";
            localGuardianAddress.Text = "";
            localGuardianPhoneNo.Text = "";
            PhoneNumber.Text = "";
        }

        protected void logInSecurity()
        {
            if (User.IsInRole("HallAuthority"))
            {
                Response.Redirect("~/Default.aspx");
            }
            else if (User.IsInRole("Student"))
            {
                Response.Redirect("~/Default.aspx");
            }
            else if (User.IsInRole("Admin"))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {

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


        protected void Apply_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var isValidRoll = new MySQLDatabase().QueryValue("countApplicationRollNo", new Dictionary<string, object>()
                {
                    {"@roll",studentid.Text }
                }, true).ToString();

                int r = int.Parse(isValidRoll);

                var isValidEmail = new MySQLDatabase().QueryValue("countApplicationEmail", new Dictionary<string, object>()
                {
                    {"@email",Email.Text }
                }, true).ToString();
                int v = int.Parse(isValidEmail);

                if (v == 0 && r == 0)
                {
                    var res = new MySQLDatabase().Execute("addApplicationInfo", new Dictionary<string, object>()
                    {
                        {"@fName",firstName.Text },
                        {"@lName",lastName.Text },
                        {"@roll",studentid.Text },
                        {"@ltCGPA",ltCGPA.Text },
                        {"@did",ddlDiscipline.SelectedValue },
                        {"@fatherName",fathersName.Text },
                        {"@fatherOccupation",fathersOccupation.Text },
                        {"@fatherYearlyIncome",fathersYearlyIncome.Text },
                        {"@motherName",mothersName.Text },
                        {"@motherOccupation",mothersOccupation.Text },
                        {"@motherYearlyIncome",mothersYearlyIncome.Text },
                        {"@batch",batch.Text },
                        {"@birthdate",DateTime.Parse(birthdate.Text) },
                        {"@sex",Sex.SelectedValue },
                        {"@bGroup",bloodGroup.Text },
                        {"@mStatus",maritalStatus.Text },
                        {"@causesOfApplication",causesOfApplication.Text },
                        {"@hid",ddlHall.SelectedValue },
                        {"@email",Email.Text },
                        {"@preAddress",presentAddress.Text },
                        {"@perAddress",permanentAddress.Text },
                        {"@lgName",localGuardianName.Text},
                        {"@lgAddress",localGuardianAddress.Text },
                        {"@lgPhoneNo",localGuardianPhoneNo.Text },
                        {"@phoneNo",PhoneNumber.Text }
                    }, true);
                    clearAllField();
                    loadApplicationId();
                    sMessage.InnerText = "Application has been submitted";
                    eMessage.Visible = false;
                    sMessage.Visible = true;
                }
                else
                {
                    eMessage.InnerText = "Application submission failed";
                    sMessage.Visible = false;
                    eMessage.Visible = true;
                }
            }else
            {
                eMessage.InnerText = "Application submission failed";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }

        protected void ddlHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDisciplineDDL();
        }
    }
}