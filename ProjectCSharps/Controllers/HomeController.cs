using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCSharps.Models;

namespace ProjectCSharps.Controllers
{
    public class HomeController : Controller
    {
        Web_CSharpsEntities all = new Web_CSharpsEntities();
        public ActionResult Index()
        {
            HomeModel m = new HomeModel();
            m.listC = all.categories.ToList();
            m.listP = all.products.ToList();

            return View(m);
        }
        public ActionResult Shop()
        {
            HomeModel m = new HomeModel();
            m.listC = all.categories.ToList();
            m.listP = all.products.ToList();

            return View(m);
        }

       
    }
}