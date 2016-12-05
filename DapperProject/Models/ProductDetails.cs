using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperProject.Models
{
    public class ProductDetails
    {
        public int? slno { get; set; }
        public string MobileName { get; set; }
        public double Price { get; set; }
        public string Url { get; set; }
        public string Features{get;set;}
        public string model { get; set; }
        public string color { get; set; }

        public string SimType { get; set; }
    }
}