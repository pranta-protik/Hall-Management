using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HallManagement.Startup))]
namespace HallManagement
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
