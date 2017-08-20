using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using HallManagement.Models;
using AspNet.Identity.MySQL;

namespace HallManagement.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage {
            get;
            private set;
        }
        protected string FailedMessage {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            if (!IsPostBack)
            {
                logInSecurity();
                loadPageAccordingUser();
                sMessage.Visible = false;
                eMessage.Visible = false;
                var user = manager.FindById(User.Identity.GetUserId());

                lblUserName.InnerText = user.UserName;
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtFatherName.Text = user.FathersName;
                txtMotherName.Text = user.MothersName;
                txtBirthdate.Text = Convert.ToDateTime(user.Birthdate).ToString("yyyy-MM-dd");
                txtEmail.Text = user.Email;
                txtMobileNum.Text = user.PhoneNumber;
                txtAddress.Text = user.Address;
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected void logInSecurity()
        {
            if (User.IsInRole("HallAuthority"))
            {

            }
            else if (User.IsInRole("Student"))
            {

            }
            else if (User.IsInRole("Admin"))
            {

            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void loadPageAccordingUser()
        {
            if (User.IsInRole("HallAuthority"))
            {
                divHallAuthority.Visible = true;
                divCommon.Visible = true;
                divAdmin.Visible = false;
                var designation = new MySQLDatabase().QueryValue("getDesignationByUId", new Dictionary<string, object>()
                {
                    {"@uid",User.Identity.GetUserId() }
                }, true);
                txtDesignation.Text = designation.ToString();
            }
            else if (User.IsInRole("Student"))
            {
                divHallAuthority.Visible = false;
                divCommon.Visible = true;
                divAdmin.Visible = false;
            }
            else if (User.IsInRole("Admin"))
            {
                divAdmin.Visible = true;
                divCommon.Visible = true;
                divHallAuthority.Visible = false;
                var sex = new MySQLDatabase().QueryValue("getSexByUId", new Dictionary<string, object>()
                {
                    {"@uid",User.Identity.GetUserId() }
                }, true);
                ddlSex.SelectedValue = sex.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (User.IsInRole("HallAuthority"))
                {
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var user = manager.FindById(User.Identity.GetUserId());
                    var isValidEmail = new MySQLDatabase().QueryValue("countManageEmail", new Dictionary<string, object>()
                    {
                        {"@email",txtEmail.Text },
                        {"@uid",user.Id }
                    }, true).ToString();
                    int v = int.Parse(isValidEmail);
                    if (v == 0)
                    {
                        user.Email = txtEmail.Text;
                        user.PhoneNumber = txtMobileNum.Text;
                        user.Address = txtAddress.Text;
                        manager.Update(user);

                        new MySQLDatabase().Execute("updateDesignationByUId", new Dictionary<string, object>()
                        {
                            {"@uid",user.Id },
                            {"@designation",txtDesignation.Text}
                        }, true);
                        sMessage.InnerText = "Your account has been updated";
                        sMessage.Visible = true;
                        eMessage.Visible = false;
                    }
                    else
                    {
                        eMessage.InnerText = "Email has already been used";
                        sMessage.Visible = false;
                        eMessage.Visible = true;
                    }
                }
                else if (User.IsInRole("Student"))
                {
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var user = manager.FindById(User.Identity.GetUserId());
                    var isValidEmail = new MySQLDatabase().QueryValue("countManageEmail", new Dictionary<string, object>()
                    {
                        {"@email",txtEmail.Text },
                        {"@uid",user.Id }
                    }, true).ToString();
                    int v = int.Parse(isValidEmail);
                    if (v == 0)
                    {
                        user.Email = txtEmail.Text;
                        user.PhoneNumber = txtMobileNum.Text;
                        user.Address = txtAddress.Text;
                        manager.Update(user);

                        sMessage.InnerText = "Your account has been updated";
                        sMessage.Visible = true;
                        eMessage.Visible = false;
                    }
                    else
                    {
                        eMessage.InnerText = "Email has already been used";
                        sMessage.Visible = false;
                        eMessage.Visible = true;
                    }
                }
                else if (User.IsInRole("Admin"))
                {
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var user = manager.FindById(User.Identity.GetUserId());
                    var isValidEmail = new MySQLDatabase().QueryValue("countManageEmail", new Dictionary<string, object>()
                    {
                        {"@email",txtEmail.Text },
                        {"@uid",user.Id }
                    }, true).ToString();
                    int v = int.Parse(isValidEmail);
                    if (v == 0)
                    {
                        user.FirstName = txtFirstName.Text;
                        user.LastName = txtLastName.Text;
                        user.FathersName = txtFatherName.Text;
                        user.MothersName = txtMotherName.Text;
                        user.Sex = ddlSex.SelectedValue;
                        user.Birthdate =DateTime.Parse(txtBirthdate.Text);
                        user.Email = txtEmail.Text;
                        user.PhoneNumber = txtMobileNum.Text;
                        user.Address = txtAddress.Text;
                        manager.Update(user);
                        sMessage.InnerText = "Your account has been updated";
                        sMessage.Visible = true;
                        eMessage.Visible = false;
                    }
                    else
                    {
                        eMessage.InnerText = "Email has already been used";
                        sMessage.Visible = false;
                        eMessage.Visible = true;
                    }
                }
            }
            else
            {
                eMessage.InnerText = "Account can not be updated";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }
    }
}