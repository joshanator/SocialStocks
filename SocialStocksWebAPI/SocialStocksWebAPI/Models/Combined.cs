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
        public static Combined Parse(List<Models.tweets> twitterData, List<Models.StockInfo> stockData, DateTime start, DateTime end)
        {
            Combined combo = new Combined();

            List<combinedPoint> comboList = new List<combinedPoint>();
            int i = stockData.Count - 1;

            while(start <= end && i >= 0)
            {
                combinedPoint s = new combinedPoint();
                s.date = start;
                if(stockData[i].date == start)
                {
                    s.stockPrice = stockData[i].price;
                    i--;
                }
                else if(i<stockData.Count-1)
                {
                    s.stockPrice = stockData[i + 1].price;
                }

                foreach(Models.tweets t in twitterData)
                {
                    if(t.date == start)
                    {
                        s.trendingValue = t.value;
                    }
                }

                start = start.AddDays(1);

                comboList.Add(s);
            }


            /*int stockCounter = stockData.Count;
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
            }*/
            combo.dataList = comboList;
            return combo;
        }
    }
}