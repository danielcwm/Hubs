using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hub.Startup))]
namespace Hub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
