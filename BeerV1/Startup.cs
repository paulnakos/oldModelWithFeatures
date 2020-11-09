using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeerV1.Startup))]
namespace BeerV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
