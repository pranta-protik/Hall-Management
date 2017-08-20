using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                loadGVNews();
                if (Request.QueryString["NewsId"] != null)
                {
                    loadNews(Convert.ToInt32(Request.QueryString["NewsId"]));
                }
            }
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

            foreach(var res in news2)
            {
                txtTitle.Text = res.Title;
                txtBody.Text = res.Body;
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

            }
            else
            {

            }
        }

        protected void lnkNews_Click(object sender, EventArgs e)
        {
            LinkButton lnkNews = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkNews.NamingContainer;
            HiddenField hfNews = (HiddenField)row.FindControl("hfNews");
            loadNews(Convert.ToInt32(hfNews.Value));
        }
    }
}