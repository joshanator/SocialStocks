using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Social_Stocks_Instrument_.Startup))]
namespace Social_Stocks_Instrument_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
