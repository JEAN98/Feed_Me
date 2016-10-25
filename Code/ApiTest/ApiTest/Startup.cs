using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApiTest.Startup))]
namespace ApiTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
