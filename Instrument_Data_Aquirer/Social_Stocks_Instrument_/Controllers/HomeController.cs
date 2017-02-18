using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using Social_Stocks_Instrument_.Models;
using System.Text;
using System.IO;

namespace Social_Stocks_Instrument_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string csvData;
            string symbols = "GOOG, IBM, FB";
            using (WebClient web = new WebClient())
            {
                string symbol;
                /*string downloadString = "http://chart.finance.yahoo.com/table.csv?s="
                    + symbol +
                    + "&a=" + startMonth + "&b=" startDay + "&c=" + startYear
                    +"&d=" + endMonth + "&e=" + endDay + "&f=" + endYear
                    +"&g=d&ignore=.csv";*/

                csvData = web.DownloadString("http://finance.yahoo.com/d/quotes/csv?s=" + symbols + "&f=sa2l1");

                //csvData = web.DownloadString(downloadString);
                List<StockInfo> stocks = YahooFinance.Parse(csvData);
                return View(stocks);
                
            }
        }

        public ActionResult Submit(string symbol, string startDate, string endDate)
        {



            return null;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}