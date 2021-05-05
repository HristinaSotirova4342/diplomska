using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Focus5.Startup))]
namespace Focus5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
