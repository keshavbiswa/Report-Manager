using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NEDRC.Startup))]
namespace NEDRC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
