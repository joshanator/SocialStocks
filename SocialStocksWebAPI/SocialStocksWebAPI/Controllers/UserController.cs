using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SocialStocksWebAPI.Controllers
{
    public class UserController : ApiController
    {
        public List<Models.tweetsByUser> Get(string symbol, string user, string keyword)
        {
            Models.byUser userData = new Models.byUser();
            List<Models.StockInfo> stockData = new List<Models.StockInfo>();
            List<Models.tweetsByUserSolo> soloData = new List<Models.tweetsByUserSolo>();

            using (System.Net.WebClient web = new WebClient())
            {
                string userDataUrl = "http://socialstocks.net/TwitterSearch/search2.php?"
                +"user=" + user + "&q=" + keyword;
                string tData = web.DownloadString(userDataUrl);
                if (tData == "[]") return userData.userTweetList;
                Models.byUserSolo s = Models.byUserConstructor.Parse(tData);
                soloData = s.justTweets;
                DateTime start = soloData[s.justTweets.Count-1].date;
                TimeSpan span = new TimeSpan(10, 0, 0, 0);
                start = start.Subtract(span);

                userData = Models.byUserConstructor.Parse(soloData, start, symbol);
            }
            userData.keyword = keyword;
            userData.symbol = symbol;
            userData.user = user;

            return userData.userTweetList;
        }

        public List<Models.tweetsByUser> Get(string symbol, string user, string keyword, int number)
        {
            Models.byUser userData = new Models.byUser();
            List<Models.StockInfo> stockData = new List<Models.StockInfo>();
            List<Models.tweetsByUserSolo> soloData = new List<Models.tweetsByUserSolo>();

            using (System.Net.WebClient web = new WebClient())
            {
                string userDataUrl = "http://socialstocks.net/TwitterSearch/search2.php?"
                + "user=" + user + "&number=" + number + "&q=" + keyword;
                string tData = web.DownloadString(userDataUrl);
                if (tData == "[]") return userData.userTweetList;
                Models.byUserSolo s = Models.byUserConstructor.Parse(tData);
                soloData = s.justTweets;
                DateTime start = soloData[s.justTweets.Count - 1].date;
                TimeSpan span = new TimeSpan(10, 0, 0, 0);
                start = start.Subtract(span);

                userData = Models.byUserConstructor.Parse(soloData, start, symbol);
            }
            userData.keyword = keyword;
            userData.symbol = symbol;
            userData.user = user;

            return userData.userTweetList;
        }

        public List<Models.tweetsByUser> Get(string symbol, string user, string keyword, DateTime start)
        {
            Models.byUser userData = new Models.byUser();
            List<Models.StockInfo> stockData = new List<Models.StockInfo>();
            List<Models.tweetsByUserSolo> soloData = new List<Models.tweetsByUserSolo>();

            using (System.Net.WebClient web = new WebClient())
            {
                string userDataUrl = "http://socialstocks.net/TwitterSearch/search2.php?"
                + "user=" + user + "&q=" + keyword;
                string tData = web.DownloadString(userDataUrl);
                if (tData == "[]") return userData.userTweetList;
                Models.byUserSolo s = Models.byUserConstructor.Parse(tData);
                soloData = s.justTweets;
                userData = Models.byUserConstructor.Parse(soloData, start, symbol);
            }
            userData.keyword = keyword;
            userData.symbol = symbol;
            userData.user = user;

            return userData.userTweetList;
        }

        public List<Models.tweetsByUser> Get(string symbol, string user, string keyword, DateTime start, DateTime end)
        {
            Models.byUser userData = new Models.byUser();
            List<Models.StockInfo> stockData = new List<Models.StockInfo>();
            List<Models.tweetsByUserSolo> soloData = new List<Models.tweetsByUserSolo>();

            using (System.Net.WebClient web = new WebClient())
            {
                string userDataUrl = "http://socialstocks.net/TwitterSearch/search2.php?"
                + "user=" + user + "&q=" + keyword;
                string tData = web.DownloadString(userDataUrl);
                if (tData == "[]") return userData.userTweetList;
                Models.byUserSolo s = Models.byUserConstructor.Parse(tData);
                soloData = s.justTweets;

                userData = Models.byUserConstructor.Parse(soloData, start, end, symbol);
            }
            userData.keyword = keyword;
            userData.symbol = symbol;
            userData.user = user;

            return userData.userTweetList;
        }

        public List<Models.tweetsByUserMultiple> Get(string symbol1, string symbol2, string user, string keyword)
        {
            string[] symbols = { symbol1, symbol2 };

            Models.byUserMultiple userData = new Models.byUserMultiple();
            List<Models.StockInfo> stockData = new List<Models.StockInfo>();
            List<Models.tweetsByUserSolo> soloData = new List<Models.tweetsByUserSolo>();

            using (System.Net.WebClient web = new WebClient())
            {
                string userDataUrl = "http://socialstocks.net/TwitterSearch/search2.php?"
                + "user=" + user + "&q=" + keyword;
                string tData = web.DownloadString(userDataUrl);
                if (tData == "[]") return userData.userTweetList;
                Models.byUserSolo s = Models.byUserConstructor.Parse(tData);
                soloData = s.justTweets;
                DateTime start = soloData[s.justTweets.Count - 1].date;
                TimeSpan span = new TimeSpan(10, 0, 0, 0);
                start = start.Subtract(span);

                userData = Models.byUserConstructor.Parse(soloData, start, symbols);
            }
            userData.keyword = keyword;
            userData.symbols = symbols;
            userData.user = user;

            return userData.userTweetList;
        }

    }
}
