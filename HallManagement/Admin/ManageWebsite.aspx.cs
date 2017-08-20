using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Admin
{
    public partial class ManageWebsite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
            }
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

        protected void btnEditAccount_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Common/ViewStudent.aspx");
        }

        protected void btnEditHome_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditHomePage.aspx");
        }

        protected void btnEditNewsNotice_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Common/AddOrEdit.aspx");
        }

        protected void btnEditHistoryContact_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditHistory.aspx");
        }
    }
}