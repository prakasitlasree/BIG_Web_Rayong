using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BIG_Web_Rayong.Startup))]
namespace BIG_Web_Rayong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
