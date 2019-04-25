using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIS174ErikJohnsonOfficial.Web.Startup))]
namespace CIS174ErikJohnsonOfficial.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
