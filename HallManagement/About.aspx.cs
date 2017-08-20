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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                checkHistoryXmlFile();
                loadHistory();
                loadHistoryImage();
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

        protected void checkHistoryXmlFile()
        {
            string historyFilePath = Server.MapPath(string.Format("~/Xml/about.xml"));
            if (!File.Exists(historyFilePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("history");
                xmlDoc.AppendChild(rootNode);
                XmlNode headingNode = xmlDoc.CreateElement("heading");
                headingNode.InnerText = "";
                rootNode.AppendChild(headingNode);
                XmlNode descriptionNode = xmlDoc.CreateElement("description");
                descriptionNode.InnerText = "";
                rootNode.AppendChild(descriptionNode);
                xmlDoc.Save(Server.MapPath("~/Xml/about.xml"));
            }
        }

        protected void loadHistory()
        {
            XmlReader reader = XmlReader.Create(Server.MapPath("~/Xml/about.xml"));
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

        protected void loadHistoryImage()
        {
            try
            {
                if (ViewState["ImgInnerHtml"] != null)
                {
                    //use the cached html
                    ltlHistoryImage.Text = ViewState["ImgInnerHtml"].ToString();
                }
                else
                {
                    //get a list of images from the folder
                    const string imagesPath = "/AboutImage/";
                    var dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(imagesPath));
                    //filtering to jpgs, but ideally not required
                    List<string> fileNames = (from flInfo in dir.GetFiles() where flInfo.Name.EndsWith(".jpg") select flInfo.Name).ToList();
                    if (fileNames.Count > 0)
                    {
                        var imgInnerHtml = new StringBuilder();
                        //loop through and build up the html for indicators + images
                        for (int i = 0; i < fileNames.Count; i++)
                        {
                            var fileName = fileNames[i];
                            imgInnerHtml.AppendLine("<img src='" + imagesPath + fileName + "' alt='Hall Image' class='img-responsive img-rounded col-md-12'" + "runat='server'" + ">");
                        }
                        //close tag
                        //stick the html in the literal tags and the cache
                        ViewState["ImgInnerHtml"] = ltlHistoryImage.Text = imgInnerHtml.ToString();
                    }
                    else
                    {
                        ltlHistoryImage.Text = "Hall Image";
                    }
                }
            }
            catch (Exception)
            {
                //something is dodgy so flush the cache
                if (ViewState["ImgInnerHtml"] != null)
                {
                    Cache.Remove("ImgInnerHtml");
                }
            }
        }
    }
}