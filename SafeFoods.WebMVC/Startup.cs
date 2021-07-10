using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafeFoods.WebMVC.Startup))]
namespace SafeFoods.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
