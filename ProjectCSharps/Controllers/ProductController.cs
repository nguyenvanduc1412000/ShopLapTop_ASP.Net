using ProjectCSharps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCSharps.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Web_CSharpsEntities objProduct = new Web_CSharpsEntities();
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