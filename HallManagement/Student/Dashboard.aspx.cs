using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HallManagement.Student
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInSecurity();
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(User.Identity.GetUserId());
                lblFullName.InnerText = user.FirstName + " " + user.LastName;
                lblEmail.InnerText = user.Email;
                lblFathersName.InnerText = user.FathersName;
                lblMothersName.InnerText = user.MothersName;
                lblPhoneNo.InnerText = user.PhoneNumber;
                lblBirthdate.InnerText = user.Birthdate.ToString("dd-MM-yyyy");
                lblSex.InnerText = user.Sex;
                lblAddress.InnerText = user.Address;

                var student = new MySQLDatabase().Query("getStudentInfo", new Dictionary<string, object>()
                {
                    {"@uid",user.Id }
                }, true);

                var res = student.Select(x => new
                {
                    RoomNo = x["roomNo"],
                    RollNo = x["rollNo"],
                    Batch = x["batch"],
                    Hall = x["hallName"],
                    Discipline = x["disciplineName"],
                    BloodGroup=x["bloodGroup"],
                    LocalGuardianName=x["localGuardianName"],
                    LocalGuardianAddress=x["localGuardianAddress"],
                    LocalGuardianPhoneNo=x["localGuardianPhoneNo"]
                }).ToList();
                foreach (var res1 in res)
                {
                    lblRoomNo.InnerText = res1.RoomNo;
                    lblStudentID.InnerText = res1.RollNo;
                    lblBatch.InnerText = res1.Batch;
                    lblHall.InnerText = res1.Hall;
                    lblDiscipline.InnerText = res1.Discipline;
                    lblBloodGroup.InnerText = res1.BloodGroup;
                    lblLocalGuardianName.InnerText = res1.LocalGuardianName;
                    lblLocalGuardianAddress.InnerText = res1.LocalGuardianAddress;
                    lblLocalGuardianPhoneNo.InnerText = res1.LocalGuardianPhoneNo;
                }
            }
        }

        protected void logInSecurity()
        {
            if (User.IsInRole("HallAuthority"))
            {
                Response.Redirect("~/HallAuthority/Dashboard.aspx");
            }
            else if (User.IsInRole("Student"))
            {
                
            }
            else if (User.IsInRole("Admin"))
            {
                Response.Redirect("~/Admin/Dashboard.aspx");
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}