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
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                checkContactXmlFile();
                loadContact();
                loadContactImage();
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

        protected void checkContactXmlFile()
        {
            string contactFilePath = Server.MapPath(string.Format("~/Xml/contact.xml"));
            if (!File.Exists(contactFilePath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("contact");
                xmlDoc.AppendChild(rootNode);
                XmlNode addressNode = xmlDoc.CreateElement("address");
                addressNode.InnerText = "";
                rootNode.AppendChild(addressNode);
                XmlNode supportNode = xmlDoc.CreateElement("support");
                supportNode.InnerText = "";
                rootNode.AppendChild(supportNode);
                XmlNode supportHrfNode = xmlDoc.CreateElement("supportHrf");
                supportHrfNode.InnerText = "";
                rootNode.AppendChild(supportHrfNode);
                XmlNode contactNoNode = xmlDoc.CreateElement("contactNo");
                contactNoNode.InnerText = "";
                rootNode.AppendChild(contactNoNode);
                xmlDoc.Save(Server.MapPath("~/Xml/contact.xml"));
            }
        }

        protected void loadContact()
        {
            XmlReader reader = XmlReader.Create(Server.MapPath("~/Xml/contact.xml"));
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name.ToString())
                    {
                        case "address":
                            txtAddress.InnerText = reader.ReadString();
                            break;
                        case "support":
                            hrefSupport.InnerText = reader.ReadString();
                            break;
                        case "supportHrf":
                            hrefSupport.HRef = String.Format("http://" + reader.ReadString());
                            break;
                        case "contactNo":
                            hrefContact.InnerText = reader.ReadString();
                            break;
                    }
                }
            }
            reader.Close();
        }

        protected void loadContactImage()
        {
            try
            {
                if (ViewState["ImgInnerHtml"] != null)
                {
                    //use the cached html
                    ltlContactImage.Text = ViewState["ImgInnerHtml"].ToString();
                }
                else
                {
                    //get a list of images from the folder
                    const string imagesPath = "/ContactImage/";
                    var dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(imagesPath));
                    //filtering to jpgs, but ideally not required
                    List<string> fileNames = (from flInfo in dir.GetFiles() where flInfo.Name.EndsWith(".jpg") select flInfo.Name).ToList();
                    if (fileNames.Count > 0)
                    {
                        var imgInnerHtmlC = new StringBuilder();
                        //loop through and build up the html for indicators + images
                        for (int i = 0; i < fileNames.Count; i++)
                        {
                            var fileName = fileNames[i];
                            imgInnerHtmlC.AppendLine("<img src='" + imagesPath + fileName + "' alt='Loaction Image' class='img-responsive img-rounded col-md-12'" + "runat='server'" + ">");
                        }
                        //close tag
                        //stick the html in the literal tags and the cache
                        ViewState["ImgInnerHtml"] = ltlContactImage.Text = imgInnerHtmlC.ToString();
                    }
                    else
                    {
                        ltlContactImage.Text = "Location Image";
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