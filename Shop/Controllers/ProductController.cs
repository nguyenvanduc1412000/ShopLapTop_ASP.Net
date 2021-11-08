using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        LAPTOP_ASPEntities objProduct = new LAPTOP_ASPEntities();
        //public ActionResult Index(string keySearch)
        //{
        //    var result = objProduct.products.Where(n => n.name_pro.Contains(keySearch)).ToList();

         
        //    return View(result);
        //}
        public ActionResult Detail(int pid)
        {
            
            
            var result = objProduct.products.Where(n => n.id_pro == pid).FirstOrDefault();
            return View(result);
        }
    }
}