using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Common
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
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

        protected void lnkAddNotice_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Common/AddNotice.aspx");
        }

        protected void clearAllField()
        {
            txtTitle.Text = "";
            txtBody.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                new MySQLDatabase().Execute("addNews", new Dictionary<string, object>()
                {
                    {"@title",txtTitle.Text },
                    {"@body",txtBody.Text }
                }, true);

                clearAllField();
                sMessage.InnerText = "News has been created";
                eMessage.Visible = false;
                sMessage.Visible = true;
            }
            else
            {
                eMessage.InnerText = "No news created";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }

        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            clearAllField();
            eMessage.InnerText = "No news created";
            sMessage.Visible = false;
            eMessage.Visible = true;
        }
    }
}