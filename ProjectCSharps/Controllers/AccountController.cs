using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCSharps.Models;

namespace ProjectCSharps.Controllers
{
    

    public class AccountController : Controller
    {
        Web_CSharpsEntities _db = new Web_CSharpsEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authen(user _user)
        {
            var check = _db.users.Where(s => s.email.Equals(_user.email) && s.password.Equals(_user.password)).FirstOrDefault();
           if(check == null)
            {
                _user.LoginErrorMessage = "Error Mail or Pass ! Try again please!";
                ViewBag.err = "Error Mail or Pass ! Try again please!";
                return View("Login", _user);

            }
            else
            {
                Session["id_user"] = _user.id_user;
                Session["email"] = _user.email;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        //method xu ly model
        public ActionResult Register(user _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.users.FirstOrDefault(s => s.email == _user.email);
                if (check == null )
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    
                    _db.users.Add(_user);

                    _db.SaveChanges();
                    // neu dk thanh cong thif dieu huowng toi login
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists!!!";
                    return View();
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login","Account");
            
        }
    }
}