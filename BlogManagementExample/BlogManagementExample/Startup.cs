using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogManagementExample.Startup))]
namespace BlogManagementExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
