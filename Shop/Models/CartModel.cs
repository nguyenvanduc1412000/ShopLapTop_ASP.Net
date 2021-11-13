using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class CartModel
    {
        public product Product { get; set; }
        public int Quantity { get; set; }
    }
}