using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAndAngularCRUD.Startup))]
namespace MVCAndAngularCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
