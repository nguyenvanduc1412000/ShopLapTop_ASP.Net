using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectCSharps.Models;

namespace ProjectCSharps.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private Web_CSharpsEntities db = new Web_CSharpsEntities();

        // GET: Admin/users
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: Admin/users/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    user user = db.users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: Admin/users/Create
        
    }
}
