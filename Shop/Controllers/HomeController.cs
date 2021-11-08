using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Shop.Controllers
{

    public class HomeController : Controller
    {
        LAPTOP_ASPEntities all = new LAPTOP_ASPEntities();
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