using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineRezervacijaBioskopskihKarata.Startup))]
namespace OnlineRezervacijaBioskopskihKarata
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
