using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrailTrackerMVC.Startup))]
namespace TrailTrackerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
