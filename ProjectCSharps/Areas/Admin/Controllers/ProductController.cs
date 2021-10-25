using ProjectCSharps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCSharps.Areas.Admin.Controllers
{

    public class ProductController : Controller
    {
        Web_CSharpsEntities b = new Web_CSharpsEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {

            var lstProduct = from e in b.products
                             orderby e.id_pro ascending
                             select e;
            return View(lstProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();   
        }
       
        public ActionResult Details(int id)
        {
            var detailP = b.products.Where(n => n.id_pro == id).FirstOrDefault();
            return View(detailP);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = b.products.Where(n => n.id_pro == id).FirstOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(product p)
        {
            var objProduct = b.products.Where(n => n.id_pro == p.id_pro).FirstOrDefault();
            b.products.Remove(objProduct);
            b.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}