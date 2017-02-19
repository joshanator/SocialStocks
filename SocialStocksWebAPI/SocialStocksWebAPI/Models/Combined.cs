using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStocksWebAPI.Models
{
    public class Combined
    {
        public string hashtag { get; set; }
        public string symbol { get; set; }
        public List<combinedPoint> dataList { get; set; }
    }

    public class combinedPoint
    {
        public DateTime date { get; set; }
        public decimal stockPrice { get; set; }
        public int trendingValue { get; set; }
    }

    public static class combinedConstructor
    {
        public static Combined Parse(List<Models.tweets> twitterData, List<Models.StockInfo> stockData)
        {
            Combined combo = new Combined();

            List<combinedPoint> comboList = new List<combinedPoint>();

            int stockCounter = stockData.Count;
            stockCounter--;

            foreach(Models.tweets tweet in twitterData)
            {
                DateTime date = tweet.date;
                combinedPoint s = new combinedPoint();
                s.date = date;
                s.trendingValue = tweet.value;

                while(stockCounter >= 0 && DateTime.Compare(date, stockData[stockCounter].date) >= 0)
                {
                    if (stockData[stockCounter].date == date)
                    {
                        s.stockPrice = stockData[stockCounter].price;
                        stockCounter--;
                        break;
                    }
                    else
                    {
                        stockCounter--;
                    }
                }
                comboList.Add(s);
            }
            combo.dataList = comboList;
            return combo;
        }
    }
}