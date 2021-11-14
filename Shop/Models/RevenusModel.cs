using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Count
    {
        public string Name { get; set; }
        public int Sum { get; set; }
        public int Persent { get; set; }
    }
    public class RevenusView
    {
        public List<Count> categoryOrder { get; set; }
        public List<Count> productOrder { get; set; }
    }
}