using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllBusinesLands.Startup))]
namespace AllBusinesLands
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
