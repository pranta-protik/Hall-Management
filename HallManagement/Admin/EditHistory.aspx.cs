using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace HallManagement.Admin
{
    public partial class EditHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                sMessage.Visible = false;
                eMessage.Visible = false;
                divUploadHistory.Visible = false;
                divDeleteHistory.Visible = false;
                checkHistoryXmlFile();
                loadHistoryImage();
                loadHistoryButton();
                loadHistory();
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
                            txtHeading.Text = reader.ReadString();
                            break;
                        case "description":
                            txtDescription.Text = reader.ReadString();
                            break;
                    }
                }
            }
            reader.Close();
        }

        protected void loadHistoryButton()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/AboutImage/"));
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }
            if (files.Count != 0)
            {
                divUploadHistory.Visible = false;
                divDeleteHistory.Visible = true;
            }
            else
            {
                divDeleteHistory.Visible = false;
                divUploadHistory.Visible = true;
            }
        }


        protected void loadHistoryImage()
        {
            try
            {
                if (ViewState["ImgInnerHtmlH"] != null)
                {
                    //use the cached html
                    ltlHistoryImage.Text = ViewState["ImgInnerHtmlH"].ToString();
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
                        var imgInnerHtmlH = new StringBuilder();
                        //loop through and build up the html for indicators + images
                        for (int i = 0; i < fileNames.Count; i++)
                        {
                            var fileName = fileNames[i];
                            imgInnerHtmlH.AppendLine("<img src='" + imagesPath + fileName + "' alt='Hall Image' class='img-responsive img-rounded col-md-12'" + "runat='server'" + ">");
                        }
                        //close tag
                        //stick the html in the literal tags and the cache
                        ViewState["ImgInnerHtmlH"] = ltlHistoryImage.Text = imgInnerHtmlH.ToString();
                    }
                    else
                    {
                        ltlHistoryImage.Text = "Upload an image with .jpg extension";
                    }
                }
            }
            catch (Exception)
            {
                //something is dodgy so flush the cache
                if (ViewState["ImgInnerHtmlH"] != null)
                {
                    Cache.Remove("ImgInnerHtmlH");
                }
            }
        }


        protected void btnUploadHistoryImage_Click(object sender, EventArgs e)
        {
            string directoryPath2 = Server.MapPath(string.Format("~/AboutImage"));
            if (Directory.Exists(directoryPath2))
            {
                string fileName = Path.GetFileName(historyImageUpload.PostedFile.FileName);
                if (fileName != "")
                {
                    historyImageUpload.PostedFile.SaveAs(Server.MapPath("~/AboutImage/") + fileName);
                    Response.Redirect(Request.Url.AbsoluteUri);
                    sMessage.InnerText = "File successfully uploaded";
                    eMessage.Visible = false;
                    sMessage.Visible = true;
                }
                else
                {
                    eMessage.InnerText = "Choose a file to upload";
                    sMessage.Visible = false;
                    eMessage.Visible = true;
                }
            }
            else
            {
                eMessage.InnerText = "Directory doesn't exist";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }

        protected void btnUpdateHistory_Click(object sender, EventArgs e)
        {
            string directoryPath4 = Server.MapPath(string.Format("~/Xml"));
            if (Directory.Exists(directoryPath4))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("history");
                xmlDoc.AppendChild(rootNode);
                XmlNode headingNode = xmlDoc.CreateElement("heading");
                headingNode.InnerText = txtHeading.Text;
                rootNode.AppendChild(headingNode);
                XmlNode descriptionNode = xmlDoc.CreateElement("description");
                descriptionNode.InnerText = txtDescription.Text;
                rootNode.AppendChild(descriptionNode);
                xmlDoc.Save(Server.MapPath("~/Xml/about.xml"));

                loadHistory();

                sMessage.InnerText = "History updated successfully";
                eMessage.Visible = false;
                sMessage.Visible = true;
            }
            else
            {
                eMessage.InnerText = "Directory doesn't exist";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }
        protected void lnkEditContact_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditContact.aspx");
        }

        protected void btnRemoveHistory_ServerClick(object sender, EventArgs e)
        {
            string directoryPath4 = Server.MapPath(string.Format("~/Xml"));
            if (Directory.Exists(directoryPath4))
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

                loadHistory();

                sMessage.InnerText = "History removed successfully";
                eMessage.Visible = false;
                sMessage.Visible = true;
            }
            else
            {
                eMessage.InnerText = "Directory doesn't exist";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }

        protected void btnDeleteHistoryImage_ServerClick(object sender, EventArgs e)
        {
            string directoryPath2 = Server.MapPath(string.Format("~/AboutImage"));
            if (Directory.Exists(directoryPath2))
            {
                var folderPath = Server.MapPath("~/AboutImage/");
                System.IO.DirectoryInfo folderInfo = new DirectoryInfo(folderPath);

                foreach (FileInfo file in folderInfo.GetFiles())
                {
                    file.Delete();
                }
                Response.Redirect(Request.Url.AbsoluteUri);
                sMessage.InnerText = "Image successfully deleted";
                eMessage.Visible = false;
                sMessage.Visible = true;
            }
            else
            {
                eMessage.InnerText = "Directory doesn't exist";
                sMessage.Visible = false;
                eMessage.Visible = true;
            }
        }
    }
}