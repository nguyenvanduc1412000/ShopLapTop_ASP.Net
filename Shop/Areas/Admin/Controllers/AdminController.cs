using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{

public class AdminController : Controller
    {

        private LAPTOP_ASPEntities db = new LAPTOP_ASPEntities();
        DateTime now = DateTime.Now;
        // GET: Admin/Admin
        public ActionResult Index()
        {
            RevenusView r = new RevenusView();
            ViewBag.Month = now.Month;
            ViewBag.Day = now.Day + "/" + now.Month;
            var eMonth = db.Orders.Where(p => p.date.Month == now.Month).Sum(p => p.totalmoney);
            ViewBag.eMonth = eMonth;
            var eDay = db.Orders.Where(p => p.date == now.Date).Sum(p => p.totalmoney);
            ViewBag.eDay = eDay;

            var orderMonth = db.Orders.Where(p => p.date.Month == now.Month).ToList();
            ViewBag.OrderMonth = orderMonth.Count;
            var orderDay = db.Orders.Where(p => p.date == now.Date).ToList();
            ViewBag.OrderDay =orderDay.Count;
            var categoryOrder = (from o in db.OrderLines
                                join p in db.products on o.pid equals p.id_pro
                                join c in db.categories on p.id_cat equals c.id_cat
                                group o.price by c into categoryCount
                                select new Count
                                {
                                    Name = categoryCount.Key.name_cat,
                                    Sum = categoryCount.Count()
                                }).ToList();
            r.categoryOrder = categoryOrder;
            var productOrder = (from o in db.OrderLines
                                join p in db.products on o.pid equals p.id_pro
                                group o.quantity by p into productCount
                                select new Count
                                {
                                    Name = productCount.Key.name_pro,
                                    Sum = (int)productCount.Sum()
                                }).Take(8).ToList();
            r.productOrder = productOrder;
            return View(r);
        }
    }
}