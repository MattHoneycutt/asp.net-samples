using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(identity_with_ioc.Startup))]
namespace identity_with_ioc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
