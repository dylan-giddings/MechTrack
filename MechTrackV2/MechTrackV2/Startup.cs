using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MechTrackV2.Startup))]
namespace MechTrackV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
