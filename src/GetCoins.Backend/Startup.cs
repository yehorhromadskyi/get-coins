using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GetCoins.Backend.Startup))]

namespace GetCoins.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}