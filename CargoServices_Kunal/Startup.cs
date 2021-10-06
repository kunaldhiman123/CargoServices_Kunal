using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CargoServices_Kunal.Startup))]
namespace CargoServices_Kunal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
