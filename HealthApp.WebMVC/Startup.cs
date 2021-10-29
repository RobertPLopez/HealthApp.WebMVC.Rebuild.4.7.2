using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthApp.WebMVC.Startup))]
namespace HealthApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
