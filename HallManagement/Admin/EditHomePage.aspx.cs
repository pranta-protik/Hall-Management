using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace HallManagement.Admin
{
    public partial class EditHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                checkMessageXmlFile();
                loadImageGridView();
                loadMessage();
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


        protected void loadImageGridView()
        {
            sMessage.Visible = false;
            eMessage.Visible = false;
            string[] ImagePaths = Directory.GetFiles(Server.MapPath("~/SlideImages/"));
            List<ListItem> Imgs = new List<ListItem>();
            foreach (string imgPath in ImagePaths)
            {
                string ImgName = Path.GetFileName(imgPath);
                Imgs.Add(new ListItem(ImgName, "~/SlideImages/" + ImgName));
            }
            gvUploadedImage.DataSource = Imgs;
            gvUploadedImage.DataBind();
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            string directoryPath1 = Server.MapPath(string.Format("~/SlideImages/"));
            if (Directory.Exists(directoryPath1))
            {
                string filePath = (sender as LinkButton).CommandArgument;
                string fileName = Path.GetFileName(filePath);
                FileInfo info = new FileInfo(Server.MapPath("~/SlideImages/") + fileName);
                if (info.Exists)
                {
                    info.Delete();
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string directoryPath1 = Server.MapPath(string.Format("~/SlideImages/"));
            if (Directory.Exists(directoryPath1))
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (fileName != "")
                {
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/SlideImages/") + fileName);
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


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string directoryPath4 = Server.MapPath(string.Format("~/Xml"));
            if (Directory.Exists(directoryPath4))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("message");
                xmlDoc.AppendChild(rootNode);
                XmlNode headingNode = xmlDoc.CreateElement("heading");
                headingNode.InnerText = txtHeading.Text;
                rootNode.AppendChild(headingNode);
                XmlNode descriptionNode = xmlDoc.CreateElement("description");
                descriptionNode.InnerText = txtDescription.Text;
                rootNode.AppendChild(descriptionNode);
                xmlDoc.Save(Server.MapPath("~/Xml/message.xml"));

                loadMessage();

                sMessage.InnerText = "Message updated successfully";
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

        protected void btnRemove_ServerClick(object sender, EventArgs e)
        {
            string directoryPath4 = Server.MapPath(string.Format("~/Xml"));
            if (Directory.Exists(directoryPath4))
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

                loadMessage();

                sMessage.InnerText = "Message removed successfully";
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