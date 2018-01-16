using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialStocksWebAPI.Models
{
    public class StockInfo
    {
        public DateTime date { get; set; }
        public decimal price { get; set; }
    }

    public class StockInfoDetailed
    {
        public DateTime date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
    }
}
