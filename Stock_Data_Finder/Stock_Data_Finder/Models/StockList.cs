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

    
}