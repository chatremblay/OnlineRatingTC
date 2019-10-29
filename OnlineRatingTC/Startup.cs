using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineRatingTC.Startup))]
namespace OnlineRatingTC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
