using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialStocksWebAPI.Controllers
{
    public class TwitterController : ApiController
    {
        public List<Models.tweets> Get(string Hashtag)
        {
            string url = "http://socialstocks.us-west-2.elasticbeanstalk.com/TwitterSearch/search3.php?q=" + Hashtag;

            using (System.Net.WebClient web = new WebClient())
            {
                string data = web.DownloadString(url);

                Models.twitterTrending trendingData = Models.Twitter.Parse(data, Hashtag);

                return trendingData.tweetList;
            }
        }
    }
}
