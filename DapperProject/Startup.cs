using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DapperProject.Startup))]
namespace DapperProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
