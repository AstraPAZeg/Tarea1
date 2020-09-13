using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tarea1FRAME.Startup))]
namespace Tarea1FRAME
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
