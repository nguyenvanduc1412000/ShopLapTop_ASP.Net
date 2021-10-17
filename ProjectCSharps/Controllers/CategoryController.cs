using ProjectCSharps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCSharps.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Web_CSharpsEntities objProductByCId = new Web_CSharpsEntities();

        public ActionResult ProductByCategoryId(int id)
        {
            HomeModel m = new HomeModel();
            m.listPByCid= objProductByCId.products.Where(n => n.id_cat == id).ToList();
            return View(m);
        }
        
    }
}