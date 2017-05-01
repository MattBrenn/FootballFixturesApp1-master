using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootballFixturesApp1.Startup))]
namespace FootballFixturesApp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
