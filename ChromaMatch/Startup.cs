using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChromaMatch.Startup))]
namespace ChromaMatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
