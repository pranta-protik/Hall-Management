using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Admin
{
    public partial class EditHallAuthority : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    logInSecurity();
                    loadHADetails();
                    loadDropdownList();
                    sMessage.Visible = false;
                    eMessage.Visible = false;
                }
            }
        }

        protected void loadHADetails()
        {
            var userId = Request.QueryString["HAUId"];
            var registerInfo = new MySQLDatabase().Query("getHARegistrationInfoByUId", new Dictionary<string, object>()
            {
                {"@uid",Request.QueryString["HAUId"] }
            }, true);

            var regInfo = registerInfo.Select(x => new
            {
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Designation = x["designation"],
                Position = x["position"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Sex = x["sex"],
                HallId = x["hallId"],
                Email = x["Email"],
                Address = x["Address"],
                PhoneNo = x["PhoneNumber"]

            }).ToList();

            foreach (var res in regInfo)
            {
                firstName.Text = res.FName;
                lastName.Text = res.LName;
                designation.Text = res.Designation;
                position.Text = res.Position;
                fathersName.Text = res.FatherName;
                mothersName.Text = res.MotherName;
                Sex.SelectedValue = res.Sex;
                birthdate.Text = Convert.ToDateTime(res.Birthdate).ToString("yyyy-MM-dd");
                ddlHall.SelectedValue = res.HallId;
                userName.Text = res.UName;
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
        }

        protected void logInSecurity()
        {
            if (User.IsInRole("Admin"))
            {

            }
            else if (User.IsInRole("HallAuthority"))
            {
                Response.Redirect("~/Default.aspx");
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

        protected void UpdateUser_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var isValidEmail = new MySQLDatabase().QueryValue("countManageEmail", new Dictionary<string, object>()
                    {
                        {"@email",Email.Text },
                        {"@uid",Request.QueryString["HAUId"] }
                    }, true).ToString();
                int v = int.Parse(isValidEmail);

                if (v == 0)
                {
                    new MySQLDatabase().Execute("updateHAInfo", new Dictionary<string, object>()
                    {
                        {"@uid",Request.QueryString["HAUId"] },
                        {"@firstName",firstName.Text },
                        {"@lastName",lastName.Text },
                        {"@designation",designation.Text },
                        {"@position",position.Text },
                        {"@fatherName",fathersName.Text },
                        {"@motherName",mothersName.Text },
                        {"@sex",Sex.SelectedValue },
                        {"@birthdate",Convert.ToDateTime(birthdate.Text) },
                        {"@hid",ddlHall.SelectedValue },
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

        protected void clearAllField()
        {
            firstName.Text = "";
            lastName.Text = "";
            designation.Text = "";
            position.Text = "";
            fathersName.Text = "";
            mothersName.Text = "";
            birthdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            userName.Text = "";
            Email.Text = "";
            PhoneNumber.Text = "";
            Address.Text = "";
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            if (Request.QueryString["HAUId"] != null)
            {
                new MySQLDatabase().Execute("deleteHAbyHAUId", new Dictionary<string, object>()
                {
                    {"@uid",Request.QueryString["HAUId"] }
                }, true);
                clearAllField();
                sMessage.InnerText = "Hall Authority account has been deleted";
                eMessage.Visible = false;
                eMessage2.Visible = false;
                sMessage.Visible = true;
            }
            else
            {
                eMessage.InnerText = "Hall Authority account can not be deleted";
                sMessage.Visible = false;
                eMessage2.Visible = false;
                eMessage.Visible = true;
            }
        }
    }
}