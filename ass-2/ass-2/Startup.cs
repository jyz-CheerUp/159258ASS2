using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ass_2.Startup))]
namespace ass_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
