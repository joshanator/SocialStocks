using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Data_Finder.Models
{
    public class StockList
    {
        public string symbol { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public List<StockInfo> dataList { get; set; }
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
            foreach (string row in rows)
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
    }
}