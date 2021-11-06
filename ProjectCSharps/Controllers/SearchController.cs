using ProjectCSharps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCSharps.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        Web_CSharpsEntities all = new Web_CSharpsEntities();
        public ActionResult Shop(category c)
        {
            HomeModel m = new HomeModel();
            m.listC = all.categories.ToList();
            m.listP = all.products.Where(p =>p.category.id_cat==c.id_cat).ToList();

            return View(m);
        }
    }
}