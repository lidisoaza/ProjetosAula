using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarageStore.Startup))]
namespace GarageStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
