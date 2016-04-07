using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdventureTravels.WebUI.Startup))]
namespace AdventureTravels.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
