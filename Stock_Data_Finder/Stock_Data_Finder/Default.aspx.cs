using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock_Data_Finder
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitUserInput(object sender, EventArgs e)
        {
            string Symbol = symbol.Text;
            DateTime startDate = sDate.SelectedDate;
            DateTime endDate = eDate.SelectedDate;

            string csvData;
            using (System.Net.WebClient web = new WebClient())
            {
                string downloadString = "http://chart.finance.yahoo.com/table.csv?s="
                    + Symbol
                    + "&a=" + (startDate.Month-1) + "&b=" + startDate.Day + "&c=" + startDate.Year
                    +"&d=" + (endDate.Month - 1) + "&e=" + endDate.Day + "&f=" + endDate.Year
                    +"&g=d&ignore=.csv";          
                 
                csvData = web.DownloadString(downloadString);

                Models.StockList stocks = Models.YahooFinance.Parse(csvData, Symbol, startDate, endDate);
                //return stocks;


            }

        }
    }
}