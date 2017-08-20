using AspNet.Identity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HallManagement.Admin
{
    public partial class ViewHallAuthority : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByUserName.Visible = false;
                divViewByDesignation.Visible = false;
                divViewByPosition.Visible = false;
                ddlViewBy.SelectedValue = "All";
                loadStudentDiv();
                loadGVByAll();
            }
        }

        protected void loadStudentDiv()
        {
            if (User.IsInRole("Admin"))
            {
                divStudentAccount.Visible = true;
            }
            else if (User.IsInRole("HallAuthority"))
            {
                divStudentAccount.Visible = false;
            }
            else if (User.IsInRole("Student"))
            {
                divStudentAccount.Visible = false;
            }
            else
            {
                divStudentAccount.Visible = false;
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

        protected void loadGVByAll()
        {
            var hallAuth = new MySQLDatabase().Query("getAllHADetail", new Dictionary<string, object>(), true);
            var hallAuthDetail = hallAuth.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = hallAuthDetail;
            gvAllHA.DataBind();
        }

        protected void ddlViewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlViewBy.SelectedValue == "All")
            {
                gvAllHA.Visible = true;
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByUserName.Visible = false;
                divViewByDesignation.Visible = false;
                divViewByPosition.Visible = false;
                loadGVByAll();
            }
            else if (ddlViewBy.SelectedValue == "Range")
            {
                gvAllHA.Visible = true;
                divViewByRange.Visible = true;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByUserName.Visible = false;
                divViewByDesignation.Visible = false;
                divViewByPosition.Visible = false;
                ddlRange.SelectedValue = "50";
                loadGVByRange50();
            }

            else if (ddlViewBy.SelectedValue == "Hall")
            {
                gvAllHA.Visible = true;
                divViewByRange.Visible = false;
                divViewByHall.Visible = true;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByUserName.Visible = false;
                divViewByDesignation.Visible = false;
                divViewByPosition.Visible = false;
                loadDDLHall();
                loadGVByHall();
            }

            else if (ddlViewBy.SelectedValue == "UserName")
            {
                gvAllHA.Visible = false;
                txtUName.Text = "";
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByUserName.Visible = true;
                divViewByPosition.Visible = false;
                divViewByDesignation.Visible = false;
            }
            else if (ddlViewBy.SelectedValue == "Name")
            {
                gvAllHA.Visible = false;
                txtName.Text = "";
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = true;
                divViewByPhoneNo.Visible = false;
                divViewByUserName.Visible = false;
                divViewByPosition.Visible = false;
                divViewByDesignation.Visible = false;
            }
            else if (ddlViewBy.SelectedValue == "Designation")
            {
                gvAllHA.Visible = false;
                txtDesignation.Text = "";
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByUserName.Visible = false;
                divViewByPosition.Visible = false;
                divViewByDesignation.Visible = true;
            }
            else if (ddlViewBy.SelectedValue == "Position")
            {
                gvAllHA.Visible = false;
                txtPosition.Text = "";
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByUserName.Visible = false;
                divViewByPosition.Visible = true;
                divViewByDesignation.Visible = false;
            }
            else if (ddlViewBy.SelectedValue == "PhoneNo")
            {
                gvAllHA.Visible = false;
                txtPhoneNo.Text = "";
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = true;
                divViewByUserName.Visible = false;
                divViewByPosition.Visible = false;
                divViewByDesignation.Visible = false;
            }
            else if (ddlViewBy.SelectedValue == "Address")
            {
                gvAllHA.Visible = false;
                txtAddress.Text = "";
                divViewByRange.Visible = false;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = true;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByUserName.Visible = false;
                divViewByPosition.Visible = false;
                divViewByDesignation.Visible = false;
            }

        }

        protected void loadGVByUName()
        {
            var hallAuth = new MySQLDatabase().Query("getHAByUName", new Dictionary<string, object>()
            {
                {"@UName",txtUName.Text }
            }, true);
            var hallAuthDetail = hallAuth.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = hallAuthDetail;
            gvAllHA.DataBind();
        }

        protected void loadGVByAddress()
        {
            var address = new MySQLDatabase().Query("getHAByAddress", new Dictionary<string, object>()
            {
                {"@address",'%'+txtAddress.Text+'%' }
            }, true);
            var addressDetail = address.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = addressDetail;
            gvAllHA.DataBind();
        }

        protected void loadGVByPhoneNo()
        {
            var phone = new MySQLDatabase().Query("getHAByPhoneNo", new Dictionary<string, object>()
            {
                {"@phoneNo",'%'+txtPhoneNo.Text }
            }, true);
            var phoneNo = phone.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = phoneNo;
            gvAllHA.DataBind();
        }

        protected void loadGVByDesignation()
        {
            var designation = new MySQLDatabase().Query("getHAByDesignation", new Dictionary<string, object>()
            {
                {"@designation",txtDesignation.Text }
            }, true);
            var designation2 = designation.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = designation2;
            gvAllHA.DataBind();
        }

        protected void loadGVByPosition()
        {
            var position = new MySQLDatabase().Query("getHAByPosition", new Dictionary<string, object>()
            {
                {"@position",txtPosition.Text }
            }, true);
            var position2 = position.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = position2;
            gvAllHA.DataBind();
        }

        protected void loadGVByName()
        {
            var name = new MySQLDatabase().Query("getHAByName", new Dictionary<string, object>()
            {
                {"@name",txtName.Text+'%' }
            }, true);
            var name2 = name.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = name2;
            gvAllHA.DataBind();
        }

        protected void loadGVByRange50()
        {
            var hallAuth = new MySQLDatabase().Query("getHAByRange50", new Dictionary<string, object>(), true);
            var hallAuthDetail = hallAuth.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = hallAuthDetail;
            gvAllHA.DataBind();
        }

        protected void loadGVByRange100()
        {
            var hallAuth = new MySQLDatabase().Query("getHAByRange100", new Dictionary<string, object>(), true);
            var hallAuthDetail = hallAuth.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = hallAuthDetail;
            gvAllHA.DataBind();
        }

        protected void loadGVByRange150()
        {
            var hallAuth = new MySQLDatabase().Query("getHAByRange150", new Dictionary<string, object>(), true);
            var hallAuthDetail = hallAuth.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = hallAuthDetail;
            gvAllHA.DataBind();
        }

        protected void loadGVByRange200()
        {
            var hallAuth = new MySQLDatabase().Query("getHAByRange200", new Dictionary<string, object>(), true);
            var hallAuthDetail = hallAuth.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = hallAuthDetail;
            gvAllHA.DataBind();
        }

        protected void loadGVByHall()
        {
            var hallAuth = new MySQLDatabase().Query("getHAByHall", new Dictionary<string, object>()
            {
                {"@HName",ddlHall.SelectedValue }
            }, true);
            var hallAuthDetail = hallAuth.Select(x => new
            {
                HAUId = x["HAUId"],
                UName = x["UserName"],
                FName = x["FirstName"],
                LName = x["LastName"],
                Email = x["Email"],
                PhoneNo = x["PhoneNumber"],
                Sex = x["sex"],
                Address = x["Address"],
                FatherName = x["fathersName"],
                MotherName = x["mothersName"],
                Birthdate = x["birthdate"],
                Designation = x["designation"],
                Position = x["position"],
                Hall = x["hallName"]
            }).ToList();

            gvAllHA.DataSource = hallAuthDetail;
            gvAllHA.DataBind();
        }

        protected void loadDDLHall()
        {
            var HName = new MySQLDatabase().Query("getAllHallName", new Dictionary<string, object>(), true);
            var hallName = HName.Select(x => new
            {
                HallName = x["hallName"]
            }).ToList();
            ddlHall.DataSource = hallName;
            ddlHall.DataTextField = "HallName";
            ddlHall.DataValueField = "HallName";
            ddlHall.DataBind();
        }

        protected void ddlRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRange.SelectedValue == "50")
            {
                gvAllHA.Visible = true;
                loadGVByRange50();
                divViewByRange.Visible = true;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByDesignation.Visible = false;
                divViewByPosition.Visible = false;
            }
            else if (ddlRange.SelectedValue == "100")
            {
                gvAllHA.Visible = true;
                loadGVByRange100();
                divViewByRange.Visible = true;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByDesignation.Visible = false;
                divViewByPosition.Visible = false;
            }
            else if (ddlRange.SelectedValue == "150")
            {
                gvAllHA.Visible = true;
                loadGVByRange150();
                divViewByRange.Visible = true;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByDesignation.Visible = false;
                divViewByPosition.Visible = false;
            }
            else if (ddlRange.SelectedValue == "200")
            {
                gvAllHA.Visible = true;
                loadGVByRange200();
                divViewByRange.Visible = true;
                divViewByHall.Visible = false;
                divViewByAddress.Visible = false;
                divViewByName.Visible = false;
                divViewByPhoneNo.Visible = false;
                divViewByDesignation.Visible = false;
                divViewByPosition.Visible = false;
            }
        }

        protected void ddlHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGVByHall();
        }

        protected void btnSearchAddress_ServerClick(object sender, EventArgs e)
        {
            if (txtAddress.Text != "")
            {
                loadGVByAddress();
                gvAllHA.Visible = true;
            }
            else
            {
                gvAllHA.Visible = false;
            }
        }

        protected void btnName_ServerClick(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                loadGVByName();
                gvAllHA.Visible = true;
            }
            else
            {
                gvAllHA.Visible = false;
            }
        }

        protected void btnPhoneNo_ServerClick(object sender, EventArgs e)
        {
            if (txtPhoneNo.Text != "")
            {
                loadGVByPhoneNo();
                gvAllHA.Visible = true;
            }
            else
            {
                gvAllHA.Visible = false;
            }
        }

        protected void btnUName_ServerClick(object sender, EventArgs e)
        {
            if (txtUName.Text != "")
            {
                loadGVByUName();
                gvAllHA.Visible = true;
            }
            else
            {
                gvAllHA.Visible = false;
            }
        }

        protected void lnkStudentAccoun_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Common/ViewStudent.aspx");
        }

        protected void btnPosition_ServerClick(object sender, EventArgs e)
        {
            loadGVByPosition();
            gvAllHA.Visible = true;
        }

        protected void btnDesignation_ServerClick(object sender, EventArgs e)
        {
            loadGVByDesignation();
            gvAllHA.Visible = true;
        }

        protected void lnkEdit_ServerClick(object sender, EventArgs e)
        {
            HtmlButton lnkEdit = (HtmlButton)sender;
            GridViewRow row = (GridViewRow)lnkEdit.NamingContainer;
            HiddenField hfHAUId = (HiddenField)row.FindControl("hfHAUId");
            Response.Redirect("~/Admin/EditHallAuthority.aspx?HAUId=" + hfHAUId.Value);
        }
    }
}