using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stock_Data_Finder.Startup))]
namespace Stock_Data_Finder
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
