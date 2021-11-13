using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Shop.Controllers
{

    public class HomeController : Controller
    {
        LAPTOP_ASPEntities all = new LAPTOP_ASPEntities();
        public ActionResult Index()
        {
            HomeModel m = new HomeModel();
            m.listP = all.products.ToList();
            m.listC = all.categories.ToList();
            return View(m);
        }

        public ActionResult Shop(string currentFilter, string searchString,category cat, string orderBy, int? page)
        {
            var query = all.categories.Select(c => new { c.id_cat, c.name_cat });
            ViewBag.Categories = new SelectList(query.AsEnumerable(), "id_cat", "name_cat");
            var list = new List<product>();
            if (string.IsNullOrEmpty(searchString))
            {
                list = all.products.ToList();
                if (orderBy == "")
                {
                    list = all.products.ToList();
                }
                else if (orderBy == "name")
                {
                    list = all.products.OrderBy(p => p.name_pro).ToList();
                }
                else if (orderBy == "name_desc")
                {
                    list = all.products.OrderByDescending(p => p.name_pro).ToList();
                }
                else if (orderBy == "price")
                {
                    list = all.products.OrderBy(p => p.price).ToList();
                }
                else if (orderBy == "price_desc")
                {
                    list = all.products.OrderByDescending(p => p.price).ToList();
                }
            }
            else
            {
                list= all.products.Where(n => n.name_pro.Contains(searchString)).ToList();
                if (orderBy == "")
                {
                    list = all.products.Where(n => n.name_pro.Contains(searchString)).ToList();
                }
                else if (orderBy == "name")
                {
                    list = all.products.Where(n => n.name_pro.Contains(searchString)).OrderBy(p => p.name_pro).ToList();
                }
                else if (orderBy == "name_desc")
                {
                    list = all.products.Where(n => n.name_pro.Contains(searchString)).OrderByDescending(p => p.name_pro).ToList();
                }
                else if (orderBy == "price")
                {
                    list = all.products.Where(n => n.name_pro.Contains(searchString)).OrderBy(p => p.price).ToList();
                }
                else if (orderBy == "price_desc")
                {
                    list = all.products.Where(n => n.name_pro.Contains(searchString)).OrderByDescending(p => p.price).ToList();
                }
            }
            if (cat.id_cat > 0)
            {
                list = list.Where(p => p.id_cat == cat.id_cat).ToList();
            }
            
            ViewBag.search = searchString;
            ViewBag.currentFile= searchString;
            ViewBag.order = orderBy;
            ViewBag.id_cat = cat.id_cat;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
       

    }
}