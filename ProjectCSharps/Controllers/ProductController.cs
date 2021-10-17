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
        Web_CSharpsEntities objProductById = new Web_CSharpsEntities();
        public ActionResult Detail(int pid)
        {
            
            
            var result = objProductById.products.Where(n => n.id_pro == pid).FirstOrDefault();
            return View(result);
        }
    }
}