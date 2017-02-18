using System.Web;
using System.Web.Mvc;

namespace Social_Stocks_Instrument_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
