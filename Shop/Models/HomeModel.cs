using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class HomeModel
    {
        public List<product> listP { get; set; }
        public List<category> listC { get; set; }
    }
}