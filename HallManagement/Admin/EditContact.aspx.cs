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
    public partial class EditContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                sMessage.Visible = false;
                eMessage.Visible = false;
                divUploadContact.Visible = false;
                divDeleteContact.Visible = false;
                checkContactXmlFile();
                loadContactImage();
                loadContactButton();
                loadContact();
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
                            txtAddress.Text = reader.ReadString();
                            break;
                        case "support":
                            txtSupport.Text = reader.ReadString();
                            break;
                        case "supportHrf":
                            txtSupportHref.Text = reader.ReadString();
                            break;
                        case "contactNo":
                            txtContact.Text = reader.ReadString();
                            break;
                    }
                }
            }
            reader.Close();
        }



        protected void loadContactButton()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/ContactImage/"));
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }
            if (files.Count != 0)
            {
                divUploadContact.Visible = false;
                divDeleteContact.Visible = true;
            }
            else
            {
                divDeleteContact.Visible = false;
                divUploadContact.Visible = true;
            }
        }


        protected void loadContactImage()
        {
            try
            {
                if (ViewState["ImgInnerHtmlC"] != null)
                {
                    //use the cached html
                    ltlContactImage.Text = ViewState["ImgInnerHtmlC"].ToString();
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
                        ViewState["ImgInnerHtmlC"] = ltlContactImage.Text = imgInnerHtmlC.ToString();
                    }
                    else
                    {
                        ltlContactImage.Text = "Upload an image with .jpg extension";
                    }
                }
            }
            catch (Exception)
            {
                //something is dodgy so flush the cache
                if (ViewState["ImgInnerHtmlC"] != null)
                {
                    Cache.Remove("ImgInnerHtmlC");
                }
            }
        }





        protected void btnUpdateContact_Click(object sender, EventArgs e)
        {
            string directoryPath4 = Server.MapPath(string.Format("~/Xml"));
            if (Directory.Exists(directoryPath4))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("contact");
                xmlDoc.AppendChild(rootNode);
                XmlNode addressNode = xmlDoc.CreateElement("address");
                addressNode.InnerText = txtAddress.Text;
                rootNode.AppendChild(addressNode);
                XmlNode supportNode = xmlDoc.CreateElement("support");
                supportNode.InnerText = txtSupport.Text;
                rootNode.AppendChild(supportNode);
                XmlNode supportHrfNode = xmlDoc.CreateElement("supportHrf");
                supportHrfNode.InnerText = txtSupportHref.Text;
                rootNode.AppendChild(supportHrfNode);
                XmlNode contactNoNode = xmlDoc.CreateElement("contactNo");
                contactNoNode.InnerText = txtContact.Text;
                rootNode.AppendChild(contactNoNode);
                xmlDoc.Save(Server.MapPath("~/Xml/contact.xml"));

                loadContact();

                sMessage.InnerText = "Contact updated successfully";
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

        protected void btnUploadContactImage_Click(object sender, EventArgs e)
        {
            string directoryPath3 = Server.MapPath(string.Format("~/ContactImage"));
            if (Directory.Exists(directoryPath3))
            {
                string fileName = Path.GetFileName(contactImageUpload.PostedFile.FileName);
                if (fileName != "")
                {
                    contactImageUpload.PostedFile.SaveAs(Server.MapPath("~/ContactImage/") + fileName);
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

        protected void lnkEditHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditHistory");
        }

        protected void btnRemoveContact_ServerClick(object sender, EventArgs e)
        {
            string directoryPath4 = Server.MapPath(string.Format("~/Xml"));
            if (Directory.Exists(directoryPath4))
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

                loadContact();

                sMessage.InnerText = "Contact removed successfully";
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

        protected void btnDeleteContactImage_ServerClick(object sender, EventArgs e)
        {
            string directoryPath3 = Server.MapPath(string.Format("~/ContactImage"));
            if (Directory.Exists(directoryPath3))
            {
                var folderPath = Server.MapPath("~/ContactImage/");
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