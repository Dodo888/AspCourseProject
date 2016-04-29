using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspCourseProject.WebUI.Startup))]
namespace AspCourseProject.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
