using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement
{
    public partial class Notice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                loadGVNotice();
                if (Request.QueryString["NoticeId"] != null)
                {
                    loadNotice(Convert.ToInt32(Request.QueryString["NoticeId"]));
                }
            }
        }

        protected void loadNotice(int noticeId)
        {
            var notice = new MySQLDatabase().Query("getNoticeById", new Dictionary<string, object>()
            {
                {"@noticeId",noticeId }
            }, true);

            var notice2 = notice.Select(x => new
            {
                Title = x["title"],
                Body = x["description"]
            }).ToList();

            foreach (var res in notice2)
            {
                txtTitle.Text = res.Title;
                txtBody.Text = res.Body;
            }
        }

        protected void loadGVNotice()
        {
            var notice = new MySQLDatabase().Query("getAllNotice", new Dictionary<string, object>(), true);

            var notice2 = notice.Select(x => new
            {
                NoticeId = x["id"],
                Title = x["title"]
            }).ToList();

            gvNotice.DataSource = notice2;
            gvNotice.DataBind();
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

        protected void lnkNotice_Click(object sender, EventArgs e)
        {
            LinkButton lnkNotice = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkNotice.NamingContainer;
            HiddenField hfNotice = (HiddenField)row.FindControl("hfNotice");
            loadNotice(Convert.ToInt32(hfNotice.Value));
        }
    }
}