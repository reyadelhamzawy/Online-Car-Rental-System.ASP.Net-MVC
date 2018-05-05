using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Car_Rental_System.Startup))]
namespace Online_Car_Rental_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
