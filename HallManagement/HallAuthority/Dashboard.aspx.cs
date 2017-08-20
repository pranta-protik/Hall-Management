using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.HallAuthority
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
                lblEmail.InnerText = user.Email;
                lblFathersName.InnerText = user.FathersName;
                lblMothersName.InnerText = user.MothersName;
                lblPhoneNo.InnerText = user.PhoneNumber;
                lblBirthdate.InnerText = user.Birthdate.ToString("dd-MM-yyyy");
                lblSex.InnerText = user.Sex;
                lblAddress.InnerText = user.Address;

                var hallAuthority = new MySQLDatabase().Query("getHallAuthorityInfo", new Dictionary<string, object>()
                {
                    {"@uid",user.Id}
                }, true);

                var res = hallAuthority.Select(x => new
                {
                    Designation=x["designation"],
                    Hall=x["hallName"],
                    Position=x["position"]
                }).ToList();

                foreach(var res1 in res)
                {
                    lblDesignation.InnerText = res1.Designation;
                    lblHall.InnerText = res1.Hall;
                    lblPosition.InnerText = res1.Position;
                }
            }
        }
        protected void logInSecurity()
        {
            if (User.IsInRole("HallAuthority"))
            {

            }
            else if (User.IsInRole("Student"))
            {
                Response.Redirect("~/Student/Dashboard.aspx");
            }
            else if (User.IsInRole("Admin"))
            {
                Response.Redirect("~/Admin/Dashboard.aspx");
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}