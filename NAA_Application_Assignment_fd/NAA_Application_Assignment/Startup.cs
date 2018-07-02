using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NAA_Application_Assignment.Startup))]
namespace NAA_Application_Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
