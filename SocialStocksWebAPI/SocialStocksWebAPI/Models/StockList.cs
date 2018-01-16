using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStocksWebAPI.Models
{
    public class StockList
    {
        public string symbol { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public List<StockInfo> dataList { get; set; }
    }

    public class StockListDetailed
    {
        public string symbol { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string interval { get; set; }
        public List<StockInfoDetailed> dataList {get; set;}
    }

    public static class YahooFinance
    {
        public static StockList Parse(string csvData, string Symbol, DateTime startDate, DateTime endDate)
        {
            StockList currentData = new StockList();
            currentData.symbol = Symbol;
            currentData.start = startDate;
            currentData.end = endDate;

            List<StockInfo> stockInfo = new List<StockInfo>();

            string[] rows = csvData.Replace("r", "").Replace("\"", "").Split('\n');
            foreach (string row in rows.Skip(1))
            {
                if (string.IsNullOrEmpty(row)) continue;
                string[] cols = row.Split(',');
                if (cols[0].Trim() != "Date")
                {
                    StockInfo s = new StockInfo();
                    s.date = Convert.ToDateTime(cols[0].Trim());
                    s.price = Convert.ToDecimal(cols[4].Trim());
                    stockInfo.Add(s);
                }

            }

            currentData.dataList = stockInfo;

            return currentData;
        }

        public static StockListDetailed Parse(string csvData, string Symbol, DateTime startDate, DateTime endDate, string interval)
        {
            StockListDetailed currentData = new StockListDetailed();
            currentData.symbol = Symbol;
            currentData.start = startDate;
            currentData.end = endDate;
            if (interval == "d") currentData.interval = "day";
            else if (interval == "m") currentData.interval = "month";
            else if (interval == "w") currentData.interval = "week";

            List<StockInfoDetailed> stockInfo = new List<StockInfoDetailed>();

            string[] rows = csvData.Replace("r", "").Replace("\"", "").Split('\n');
            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;
                string[] cols = row.Split(',');
                if (cols[0].Trim() != "Date")
                {
                    StockInfoDetailed s = new StockInfoDetailed();
                    s.date = Convert.ToDateTime(cols[0].Trim());
                    s.Open = Convert.ToDecimal(cols[1].Trim());
                    s.High = Convert.ToDecimal(cols[2].Trim());
                    s.Low = Convert.ToDecimal(cols[3].Trim());
                    s.Close = Convert.ToDecimal(cols[4].Trim());
                    s.AdjClose = Convert.ToDecimal(cols[6].Trim());
                    stockInfo.Add(s);
                }

            }

            currentData.dataList = stockInfo;

            return currentData;
        }
    }
}