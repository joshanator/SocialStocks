using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStocksWebAPI.Models
{
    public class tweets
    {
        public DateTime date { get; set; }
        public int value { get; set; }
    }

    public class twitterTrending
    {
        public string hashtag { get; set; }
        public List<tweets> tweetList { get; set; }
    }

    public static class Twitter
    {
        public static twitterTrending Parse(string data, string hashtag)
        {
            twitterTrending hashtagTweets = new twitterTrending();
            hashtagTweets.hashtag = hashtag;

            List<tweets> tweetData = new List<tweets>();

            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            foreach(var kv in dict)
            {
                tweets tweet = new tweets();
                string date = kv.Key.Trim();
                date = date.Insert(2, "-");
                date = date.Insert(5, "-");
                tweet.date = Convert.ToDateTime(date);
                tweet.value = Convert.ToInt16(kv.Value.Trim());
                tweetData.Add(tweet);
            }


            hashtagTweets.tweetList = tweetData; 

            return hashtagTweets;

        }
    }
}