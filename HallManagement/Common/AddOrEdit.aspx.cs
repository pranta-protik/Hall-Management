using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Common
{
    public partial class AddOrEdit : System.Web.UI.Page
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

        protected void btnAddNew_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Common/AddNews.aspx");
        }

        protected void btnEdit_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Common/EditNews.aspx");
        }
    }
}