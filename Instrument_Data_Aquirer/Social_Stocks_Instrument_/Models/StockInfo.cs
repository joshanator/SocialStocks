using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Stocks_Instrument_.Models
{
    public class StockInfo
    {
        public string Symbol { get; set; }
        public decimal AverageVolume { get; set; }
        public decimal LastTradePrice { get; set; }

    }
    public static class YahooFinance
    {
        public static List<StockInfo> Parse(string csvData)
        {
            try
            {
                List<StockInfo> stocks = new List<StockInfo>();
                string[] rows = csvData.Replace("r", "").Replace("\"", "").Split('\n');
                foreach (string row in rows)
                {
                    if (string.IsNullOrEmpty(row)) continue;
                    string[] cols = row.Split(',');
                    StockInfo s = new StockInfo();
                    s.Symbol = cols[0].Trim();
                    s.AverageVolume = Convert.ToDecimal((cols[1] == "N/A") ? "0" : cols[1]);
                    s.LastTradePrice = Convert.ToDecimal((cols[2] == "N/A") ? "0" : cols[2]);
                    stocks.Add(s);
                }
                return stocks;
            }
            catch (Exception e)
            {
                string error = e.Message.ToString();
            }
            return null;
        }
    }
}