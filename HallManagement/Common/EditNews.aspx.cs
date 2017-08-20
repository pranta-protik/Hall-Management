using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Common
{
    public partial class EditNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                loadGVNews();
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

        protected void loadGVNews()
        {
            var news = new MySQLDatabase().Query("getAllNews", new Dictionary<string, object>(), true);

            var news2 = news.Select(x => new
            {
                NewsId = x["id"],
                Title = x["title"]
            }).ToList();

            gvNews.DataSource = news2;
            gvNews.DataBind();
        }

        protected void loadNews(int newsId)
        {
            var news = new MySQLDatabase().Query("getNewsById", new Dictionary<string, object>()
            {
                {"@newsId",newsId }
            }, true);

            var news2 = news.Select(x => new
            {
                Title = x["title"],
                Body = x["description"]
            }).ToList();

            foreach (var res in news2)
            {
                txtTitle.Text = res.Title;
                txtBody.Text = res.Body;
            }
        }

        protected void lnkNews_Click(object sender, EventArgs e)
        {
            LinkButton lnkNews = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkNews.NamingContainer;
            HiddenField hfNews = (HiddenField)row.FindControl("hfNews");
            loadNews(Convert.ToInt32(hfNews.Value));
            hfCurrentNews.Value = hfNews.Value;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                new MySQLDatabase().Execute("updateNewsById", new Dictionary<string, object>()
                {
                    {"@newsId",hfCurrentNews.Value },
                    {"@title",txtTitle.Text },
                    {"@body",txtBody.Text }
                }, true);
                loadGVNews();
                sMessage.InnerText = "News successfully updated";
                eMessage.Visible = false;
                sMessage.Visible = true;
            }
            else
            {
                eMessage.InnerText = "News can not be updated";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }

        protected void lnkEditNotice_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Common/EditNotice.aspx");
        }

        protected void clearAllField()
        {
            txtTitle.Text = "";
            txtBody.Text = "";
            hfCurrentNews.Value = "";
        }

        protected void btnRemoveNews_ServerClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                new MySQLDatabase().Execute("deleteNewsById", new Dictionary<string, object>()
                {
                    {"@newsId",hfCurrentNews.Value }
                }, true);
                loadGVNews();
                sMessage.InnerText = "News successfully deleted";
                eMessage.Visible = false;
                sMessage.Visible = true;
                clearAllField();
            }
            else
            {
                eMessage.InnerText = "News can not be deleted";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }
    }
}