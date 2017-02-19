﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialStocksWebAPI.Controllers
{
    public class StocksController : ApiController
    {
        public List<Models.StockInfo> Get(string symbol, string start, string end)
        {
            string Symbol = symbol;
            DateTime startDate = Convert.ToDateTime(start);//Convert.ToDateTime("11 / 30 / 2015 12:00:00 AM");
            DateTime endDate = Convert.ToDateTime(end); // DateTime.Today;

            string csvData;
            using (System.Net.WebClient web = new WebClient())
            {
                string downloadString = "http://chart.finance.yahoo.com/table.csv?s="
                    + Symbol
                    + "&a=" + (startDate.Month - 1) + "&b=" + startDate.Day + "&c=" + startDate.Year
                    + "&d=" + (endDate.Month - 1) + "&e=" + endDate.Day + "&f=" + endDate.Year
                    + "&g=d&ignore=.csv";

                csvData = web.DownloadString(downloadString);

                Models.StockList stocks = Models.YahooFinance.Parse(csvData, Symbol, startDate, endDate);
                return stocks.dataList;
            }
        }

        public List<Models.StockInfo> Get(string symbol, string start)
        {
            string Symbol = symbol;
            DateTime startDate = Convert.ToDateTime(start);//Convert.ToDateTime("11 / 30 / 2015 12:00:00 AM");
            DateTime endDate = DateTime.Today;

            string csvData;
            using (System.Net.WebClient web = new WebClient())
            {
                string downloadString = "http://chart.finance.yahoo.com/table.csv?s="
                    + Symbol
                    + "&a=" + (startDate.Month - 1) + "&b=" + startDate.Day + "&c=" + startDate.Year
                    + "&d=" + (endDate.Month - 1) + "&e=" + endDate.Day + "&f=" + endDate.Year
                    + "&g=d&ignore=.csv";

                csvData = web.DownloadString(downloadString);

                Models.StockList stocks = Models.YahooFinance.Parse(csvData, Symbol, startDate, endDate);
                return stocks.dataList;
            }
        }

        public List<Models.StockInfo> Get(string symbol, int years)
        {
            string Symbol = symbol;
            DateTime now = DateTime.Today;
            DateTime startDate = new DateTime((now.Year - years), now.Month, now.Day, 0, 0, 0);
            DateTime endDate = DateTime.Today;

            string csvData;
            using (System.Net.WebClient web = new WebClient())
            {
                string downloadString = "http://chart.finance.yahoo.com/table.csv?s="
                    + Symbol
                    + "&a=" + (startDate.Month - 1) + "&b=" + startDate.Day + "&c=" + startDate.Year
                    + "&d=" + (endDate.Month - 1) + "&e=" + endDate.Day + "&f=" + endDate.Year
                    + "&g=d&ignore=.csv";

                csvData = web.DownloadString(downloadString);

                Models.StockList stocks = Models.YahooFinance.Parse(csvData, Symbol, startDate, endDate);
                return stocks.dataList;
            }
        }

        public List<Models.StockInfo> Get(string symbol)
        {
            string Symbol = symbol;
            DateTime now = DateTime.Today;
            DateTime startDate = new DateTime((now.Year - 1), now.Month, now.Day, 0, 0, 0);
            DateTime endDate = DateTime.Today;

            string csvData;
            using (System.Net.WebClient web = new WebClient())
            {
                string downloadString = "http://chart.finance.yahoo.com/table.csv?s="
                    + Symbol
                    + "&a=" + (startDate.Month - 1) + "&b=" + startDate.Day + "&c=" + startDate.Year
                    + "&d=" + (endDate.Month - 1) + "&e=" + endDate.Day + "&f=" + endDate.Year
                    + "&g=d&ignore=.csv";

                csvData = web.DownloadString(downloadString);

                Models.StockList stocks = Models.YahooFinance.Parse(csvData, Symbol, startDate, endDate);
                return stocks.dataList;
            }
        }

        public List<Models.StockInfo> Get(string symbol, string start, string end, string interval)
        {
            string Symbol = symbol;
            DateTime startDate = Convert.ToDateTime(start);//Convert.ToDateTime("11 / 30 / 2015 12:00:00 AM");
            DateTime endDate = Convert.ToDateTime(end); // DateTime.Today;

            string csvData;
            using (System.Net.WebClient web = new WebClient())
            {
                string downloadString = "http://chart.finance.yahoo.com/table.csv?s="
                    + Symbol
                    + "&a=" + (startDate.Month - 1) + "&b=" + startDate.Day + "&c=" + startDate.Year
                    + "&d=" + (endDate.Month - 1) + "&e=" + endDate.Day + "&f=" + endDate.Year
                    + "&g=" + interval 
                    + "&ignore=.csv";

                csvData = web.DownloadString(downloadString);

                Models.StockList stocks = Models.YahooFinance.Parse(csvData, Symbol, startDate, endDate);
                return stocks.dataList;
            }
        }


    }
}