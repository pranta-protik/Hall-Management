using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Common
{
    public partial class EditNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                loadGVNotice();
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

        protected void lnkEditNews_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Common/EditNews.aspx");
        }

        protected void clearAllField()
        {
            txtTitle.Text = "";
            txtBody.Text = "";
            hfCurrentNotice.Value = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                new MySQLDatabase().Execute("updateNoticeById", new Dictionary<string, object>()
                {
                    {"@noticeId",hfCurrentNotice.Value },
                    {"@title",txtTitle.Text },
                    {"@body",txtBody.Text }
                }, true);
                loadGVNotice();
                sMessage.InnerText = "Notice successfully updated";
                eMessage.Visible = false;
                sMessage.Visible = true;
            }
            else
            {
                eMessage.InnerText = "Notice can not be updated";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }

        protected void btnRemoveNotice_ServerClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                new MySQLDatabase().Execute("deleteNoticeById", new Dictionary<string, object>()
                {
                    {"@noticeId",hfCurrentNotice.Value }
                }, true);
                loadGVNotice();
                sMessage.InnerText = "Notice successfully deleted";
                eMessage.Visible = false;
                sMessage.Visible = true;
                clearAllField();
            }
            else
            {
                eMessage.InnerText = "Notice can not be deleted";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }

        protected void lnkNotice_Click(object sender, EventArgs e)
        {
            LinkButton lnkNotice = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkNotice.NamingContainer;
            HiddenField hfNotice = (HiddenField)row.FindControl("hfNotice");
            loadNotice(Convert.ToInt32(hfNotice.Value));
            hfCurrentNotice.Value = hfNotice.Value;
        }
    }
}