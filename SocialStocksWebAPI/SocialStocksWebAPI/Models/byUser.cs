using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SocialStocksWebAPI.Models
{
    public class byUser
    {
        public string user { get; set; }
        public string symbol { get; set; }
        public string keyword { get; set; }
        public List<tweetsByUser> userTweetList { get; set; }
    }

    public class tweetsByUser
    {
        public DateTime date { get; set; }
        public decimal price { get; set; }
        public int count { get; set; }
    }

    public class byUserMultiple
    {
        public string user { get; set; }
        public string[] symbols { get; set; }
        public string keyword { get; set; }
        public List<tweetsByUserMultiple> userTweetList { get; set; }
    }
    public class tweetsByUserMultiple
    {
        public DateTime date { get; set; }

        public decimal[] prices { get; set; }
        public int count { get; set; }
    }

    public class byUserSolo
    {
        public List<tweetsByUserSolo> justTweets { get; set; }
    }

    public class tweetsByUserSolo
    {
        public DateTime date { get; set; }
        public int count { get; set; }
    }


    public static class byUserConstructor
    {
        public static byUser Parse(List<tweetsByUserSolo> tList, DateTime start, string symbol)
        {
            byUser final = new byUser();
            List<tweetsByUser> finalList = new List<tweetsByUser>();
            Models.StockList stocks = new Models.StockList();

            string Symbol = symbol;
            DateTime startDate = start;
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

                stocks = Models.YahooFinance.Parse(csvData, Symbol, startDate, endDate);
            }

            DateTime cur = start;
            while(cur <= DateTime.Now)
            {
                tweetsByUser temp = new tweetsByUser();
                temp.date = cur;

                foreach (Models.StockInfo s in stocks.dataList)
                {
                    if(s.date == cur)
                    {
                        temp.price = s.price;
                    }
                }
                foreach (tweetsByUserSolo t in tList)
                {
                    if (t.date == cur)
                    {
                        temp.count = t.count;
                    }
                }
                cur = cur.AddDays(1);

                finalList.Add(temp);
            }

            for(int i=0; i < finalList.Count; i++)
            {
                if (finalList[i].price == 0 && i > 0)
                {
                    finalList[i].price = finalList[i - 1].price;
                }
                else if(finalList[i].price == 0 && i == 0)
                {
                    finalList.RemoveAt(i);
                    i--;
                }
            }

            final.userTweetList = finalList;
            return final;
        }

        public static byUser Parse(List<tweetsByUserSolo> tList, DateTime start, DateTime end, string symbol)
        {
            byUser final = new byUser();
            List<tweetsByUser> finalList = new List<tweetsByUser>();
            Models.StockList stocks = new Models.StockList();

            string Symbol = symbol;
            DateTime startDate = start;
            DateTime endDate = end;

            string csvData;
            using (System.Net.WebClient web = new WebClient())
            {
                string downloadString = "http://chart.finance.yahoo.com/table.csv?s="
                    + Symbol
                    + "&a=" + (startDate.Month - 1) + "&b=" + startDate.Day + "&c=" + startDate.Year
                    + "&d=" + (endDate.Month - 1) + "&e=" + endDate.Day + "&f=" + endDate.Year
                    + "&g=d&ignore=.csv";

                csvData = web.DownloadString(downloadString);

                stocks = Models.YahooFinance.Parse(csvData, Symbol, startDate, endDate);
            }

            DateTime cur = start;
            while (cur <= DateTime.Now)
            {
                tweetsByUser temp = new tweetsByUser();
                temp.date = cur;

                foreach (Models.StockInfo s in stocks.dataList)
                {
                    if (s.date == cur)
                    {
                        temp.price = s.price;
                    }
                }
                foreach (tweetsByUserSolo t in tList)
                {
                    if (t.date == cur)
                    {
                        temp.count = t.count;
                    }
                }
                cur = cur.AddDays(1);

                finalList.Add(temp);
            }

            for (int i = 0; i < finalList.Count; i++)
            {
                if (finalList[i].price == 0 && i > 0)
                {
                    finalList[i].price = finalList[i - 1].price;
                }
                else if (finalList[i].price == 0 && i == 0)
                {
                    finalList.RemoveAt(i);
                    i--;
                }
            }

            final.userTweetList = finalList;
            return final;
        }

        public static byUserMultiple Parse(List<tweetsByUserSolo> tList, DateTime start, string[] symbols)
        {
            byUserMultiple final = new byUserMultiple();
            List<tweetsByUserMultiple> finalList = new List<tweetsByUserMultiple>();
            List<Models.StockList> stocks = new List<Models.StockList>();

            DateTime startDate = start;
            DateTime endDate = DateTime.Today;

            string csvData;
            using (System.Net.WebClient web = new WebClient())
            {
                foreach (string Symbol in symbols)
                {
                    string downloadString = "http://chart.finance.yahoo.com/table.csv?s="
                    + Symbol
                    + "&a=" + (startDate.Month - 1) + "&b=" + startDate.Day + "&c=" + startDate.Year
                    + "&d=" + (endDate.Month - 1) + "&e=" + endDate.Day + "&f=" + endDate.Year
                    + "&g=d&ignore=.csv";

                    csvData = web.DownloadString(downloadString);

                    stocks.Add(Models.YahooFinance.Parse(csvData, Symbol, startDate, endDate));
                }

            }

            DateTime cur = start;
            while (cur <= DateTime.Now)
            {
                tweetsByUserMultiple temp = new tweetsByUserMultiple();
                temp.date = cur;
                temp.prices = new decimal[symbols.Length];
                int i = 0;
                foreach (Models.StockList sList in stocks)
                {
                    foreach (Models.StockInfo s in sList.dataList)
                    {
                        if (s.date == cur)
                        {
                            temp.prices[i] = s.price;
                        }
                    }
                    i++;
                }

                foreach (tweetsByUserSolo t in tList)
                {
                    if (t.date == cur)
                    {
                        temp.count = t.count;
                    }
                }
                cur = cur.AddDays(1);

                finalList.Add(temp);
            }

            for (int i = 0; i < finalList.Count; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (finalList[i].prices[j] == 0 && i > 0)
                    {
                        finalList[i].prices[j] = finalList[i - 1].prices[j];
                    }
                    /*else if (finalList[i].prices[j] == 0 && i == 0)
                    {
                        finalList.RemoveAt(i);
                        i--;
                    }*/
                }
            }

            final.userTweetList = finalList;
            return final;
        }


        public static byUserSolo Parse(string data)
        {
            byUserSolo justTweetsList = new byUserSolo();
            List<tweetsByUserSolo> justTweets = new List<tweetsByUserSolo>();

            if (data.Length > 2)
            {
                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                foreach (var kv in dict)
                {
                    tweetsByUserSolo tweet = new tweetsByUserSolo();
                    string date = kv.Key.Trim();
                    date = date.Insert(2, "-");
                    date = date.Insert(5, "-");
                    tweet.date = Convert.ToDateTime(date);
                    tweet.count = Convert.ToInt16(kv.Value.Trim());
                    justTweets.Add(tweet);
                }
                justTweetsList.justTweets = justTweets;

            }
            return justTweetsList;
        }



    }
}
