using HallManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using AspNet.Identity.MySQL;
using System.IO;

namespace HallManagement
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            createRoles();
            createFolders();
        }

        private void createFolders()
        {
            string directoryPath1 = Server.MapPath(string.Format("~/SlideImages/"));
            if (!Directory.Exists(directoryPath1))
            {
                Directory.CreateDirectory(directoryPath1);
            }
            string directoryPath2 = Server.MapPath(string.Format("~/AboutImage"));
            if (!Directory.Exists(directoryPath2))
            {
                Directory.CreateDirectory(directoryPath2);
            }
            string directoryPath3 = Server.MapPath(string.Format("~/ContactImage"));
            if (!Directory.Exists(directoryPath3))
            {
                Directory.CreateDirectory(directoryPath3);
            }
            string directoryPath4 = Server.MapPath(string.Format("~/Xml"));
            if (!Directory.Exists(directoryPath4))
            {
                Directory.CreateDirectory(directoryPath4);
            }
        }

        private void createRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleStore = new AspNet.Identity.MySQL.RoleStore<AspNet.Identity.MySQL.IdentityRole>(context);
            var roleManager = new RoleManager<AspNet.Identity.MySQL.IdentityRole>(roleStore);

            if (!roleManager.RoleExists("HallAuthority"))
            {
                var res = roleManager.Create(new AspNet.Identity.MySQL.IdentityRole("HallAuthority"));
                if (!res.Succeeded)
                    throw new Exception(res.Errors.FirstOrDefault());
            }
            if (!roleManager.RoleExists("Student"))
            {
                var res = roleManager.Create(new AspNet.Identity.MySQL.IdentityRole("Student"));
                if (!res.Succeeded)
                    throw new Exception(res.Errors.FirstOrDefault());
            }
            if (!roleManager.RoleExists("Admin"))
            {
                var res = roleManager.Create(new AspNet.Identity.MySQL.IdentityRole("Admin"));
                if (!res.Succeeded)
                    throw new Exception(res.Errors.FirstOrDefault());
            }
        }
    }
}