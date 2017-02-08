using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pyrotechnics.Startup))]
namespace Pyrotechnics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
