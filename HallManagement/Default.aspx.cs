using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace HallManagement
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                checkMessageXmlFile();
                loadImageSlideShow();
                loadMessage();
                loadNews();
                loadNotice();
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

            }
            else
            {

            }
        }

        protected void checkMessageXmlFile()
        {
            string historyFilePath = Server.MapPath(string.Format("~/Xml/message.xml"));
            if (!File.Exists(historyFilePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("message");
                xmlDoc.AppendChild(rootNode);
                XmlNode headingNode = xmlDoc.CreateElement("heading");
                headingNode.InnerText = "";
                rootNode.AppendChild(headingNode);
                XmlNode descriptionNode = xmlDoc.CreateElement("description");
                descriptionNode.InnerText = "";
                rootNode.AppendChild(descriptionNode);
                xmlDoc.Save(Server.MapPath("~/Xml/message.xml"));
            }
        }

        protected void loadMessage()
        {
            XmlReader reader = XmlReader.Create(Server.MapPath("~/Xml/message.xml"));
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name.ToString())
                    {
                        case "heading":
                            lblHeading.InnerText = reader.ReadString();
                            break;
                        case "description":
                            txtDescription.InnerText = reader.ReadString();
                            break;
                    }
                }
            }
            reader.Close();
        }

        protected void loadImageSlideShow()
        {
            try
            {
                if (ViewState["CarouselInnerHtml"] != null && ViewState["CarouselIndicatorsHtml"] != null)
                {
                    //use the cached html
                    ltlCarouselImages.Text = ViewState["CarouselInnerHtml"].ToString();
                    ltlCarouselIndicators.Text = ViewState["CarouselIndicatorsHtml"].ToString();
                }
                else
                {
                    //get a list of images from the folder
                    const string imagesPath = "/SlideImages/";
                    var dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(imagesPath));
                    //filtering to jpgs, but ideally not required
                    List<string> fileNames = (from flInfo in dir.GetFiles() where flInfo.Name.EndsWith(".jpg") select flInfo.Name).ToList();
                    if (fileNames.Count > 0)
                    {
                        var carouselInnerHtml = new StringBuilder();
                        var indicatorsHtml = new StringBuilder(@"<ol class='carousel-indicators'>");
                        //loop through and build up the html for indicators + images
                        for (int i = 0; i < fileNames.Count; i++)
                        {
                            var fileName = fileNames[i];
                            carouselInnerHtml.AppendLine(i == 0 ? "<div class='item active'>" : "<div class='item'>");
                            carouselInnerHtml.AppendLine("<img src='" + imagesPath + fileName + "' alt='Image #" + (i + 1) + "' class='img-responsive'" + ">");
                            carouselInnerHtml.AppendLine("</div>");
                            indicatorsHtml.AppendLine(i == 0 ? @"<li data-target='#myCarousel' data-slide-to='" + i + "' class='active'></li>" : @"<li data-target='#myCarousel' data-slide-to='" + i + "'></li>");
                        }
                        //close tag
                        indicatorsHtml.AppendLine("</ol>");
                        //stick the html in the literal tags and the cache
                        ViewState["CarouselInnerHtml"] = ltlCarouselImages.Text = carouselInnerHtml.ToString();
                        ViewState["CarouselIndicatorsHtml"] = ltlCarouselIndicators.Text = indicatorsHtml.ToString();
                    }
                }
            }
            catch (Exception)
            {
                //something is dodgy so flush the cache
                if (ViewState["CarouselInnerHtml"] != null)
                {
                    Cache.Remove("CarouselInnerHtml");
                }
                if (ViewState["CarouselIndicatorsHtml"] != null)
                {
                    Cache.Remove("CarouselIndicatorsHtml");
                }
            }
        }

        protected void loadNews()
        {
            var news = new MySQLDatabase().Query("getLatestNews", new Dictionary<string, object>(), true);

            var news2 = news.Select(x => new
            {
                NewsId=x["id"],
                Title=x["title"]
            }).ToList();

            gvNews.DataSource = news2;
            gvNews.DataBind();
        }

        protected void loadNotice()
        {
            var notice = new MySQLDatabase().Query("getLatestNotice", new Dictionary<string, object>(), true);

            var notice2 = notice.Select(x => new
            {
                NoticeId = x["id"],
                Title = x["title"]
            }).ToList();

            gvNotice.DataSource = notice2;
            gvNotice.DataBind();
        }
     
        protected void lnkNews_Click(object sender, EventArgs e)
        {
            LinkButton lnkNews = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkNews.NamingContainer;
            HiddenField hfNews = (HiddenField)row.FindControl("hfNews");
            Response.Redirect("~/News.aspx?NewsId=" + hfNews.Value);
        }

        protected void lnkNotice_Click(object sender, EventArgs e)
        {
            LinkButton lnkNotice = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkNotice.NamingContainer;
            HiddenField hfNotice = (HiddenField)row.FindControl("hfNotice");
            Response.Redirect("~/Notice.aspx?NoticeId=" + hfNotice.Value);
        }
    }
}