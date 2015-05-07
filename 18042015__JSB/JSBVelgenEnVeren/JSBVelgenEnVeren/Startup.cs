using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JSBVelgenEnVeren.Startup))]
namespace JSBVelgenEnVeren
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
