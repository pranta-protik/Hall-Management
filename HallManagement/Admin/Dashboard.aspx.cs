using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(User.Identity.GetUserId());
                lblFullName.InnerText = user.FirstName + " " + user.LastName;
                lblFathersName.InnerText = user.FathersName;
                lblMothersName.InnerText = user.MothersName;
                lblSex.InnerText = user.Sex;
                lblBirthdate.InnerText = user.Birthdate.ToString("dd-MM-yyyy");
                lblEmail.InnerText = user.Email;
                lblPhoneNo.InnerText = user.PhoneNumber;
                lblAddress.InnerText = user.Address;
            }
        }
        protected void logInSecurity()
        {
            if (User.IsInRole("Student"))
            {
                Response.Redirect("~/Student/Dashboard.aspx");
            }
            else if (User.IsInRole("HallAuthority"))
            {
                Response.Redirect("~/HallAuthority/Dashboard.aspx");
            }
            else if (User.IsInRole("Admin"))
            {

            }else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}