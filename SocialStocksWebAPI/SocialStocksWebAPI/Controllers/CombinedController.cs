using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SocialStocksWebAPI.Controllers
{
    public class CombinedController : ApiController
    {
        public List<Models.combinedPoint> Get(string Hashtag, string symbol)
        {
            List<Models.tweets> twitterData = new List<Models.tweets>();
            List<Models.StockInfo> stockData = new List<Models.StockInfo>();
            DateTime start;
            DateTime end;

            using (System.Net.WebClient web = new WebClient())
            {
                string TDataUrl = "http://socialstocks.net/TwitterSearch/search3.php?q=" + Hashtag;
                string tData = web.DownloadString(TDataUrl);
                Models.twitterTrending trendingData = Models.Twitter.Parse(tData, Hashtag);
                twitterData = trendingData.tweetList;
                 start = twitterData[0].date;
                end = twitterData[twitterData.Count - 1].date;

                string SDataUrl = "http://" + HttpContext.Current.Request["HTTP_HOST"]
                    + "/api/Stocks/?symbol=" + symbol + "&start=" + start + "&end=" + end;
                string sData = web.DownloadString(SDataUrl);
                sData = sData.Substring(1, sData.Length - 2);
                sData = sData.Replace("date", "");
                sData = sData.Replace("price", "");
                sData = sData.Replace(":", "");
                sData = sData.Replace('"', ' ');
                sData = sData.Replace('{', ' ');
                sData = sData.Replace('}', ' ');
                sData = sData.Replace("T000000", "");
                sData = sData.Replace(" ", "");


                string[] strippedSData = sData.Split(',');
                for(int i=0; i < strippedSData.Length -1; i++)
                {
                    Models.StockInfo s = new Models.StockInfo();
                    s.date = Convert.ToDateTime(strippedSData[i]);
                    i++;
                    s.price = Convert.ToDecimal(strippedSData[i]);
                    stockData.Add(s);
                }
            }

            Models.Combined comboData = Models.combinedConstructor.Parse(twitterData, stockData, start, end);
            comboData.hashtag = Hashtag;
            comboData.symbol = symbol;


            return comboData.dataList;
        }
    }
}
