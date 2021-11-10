using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    

    public class AccountController : Controller
    {
        LAPTOP_ASPEntities _db = new LAPTOP_ASPEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authen(user _user)
        {
            var check = _db.users.Where(s => s.email.Equals(_user.email) && s.password.Equals(_user.password)).FirstOrDefault();
           if(check == null||_user.email==null||_user.password==null)
            {
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
                    ViewBag.error = "Sign up success";
                    //return RedirectToAction("Index");
                    return RedirectToAction("Login", "Account");
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
        [HttpGet]
        public ActionResult ChangePass()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ChangePass(user _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.users.Where(s => s.password.Equals(_user.password) && s.email.Equals(_user.email)).FirstOrDefault();
                if (check == null)
                {
                    ViewBag.err = "Information Incorrect!!!";
                    return View("ChangePass");

                   
                   
                }
                else
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    
                    _db.users.Add(_user);

                    _db.SaveChanges();
                    // neu dk thanh cong thif dieu huowng toi login
                    ViewBag.error = "Change Pass success";
                    //return RedirectToAction("Index");
                   // return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }


    }
}