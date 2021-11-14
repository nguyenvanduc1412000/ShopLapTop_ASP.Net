using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                Session["role"] = _user.role;
               
                return RedirectToAction("Index","Home");
            }
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
                var check = _db.users.Where(s => s.email.Equals(_user.email) && s.password.Equals(_user.password)).FirstOrDefault();

                if (check == null)
                {
                    ViewBag.err = "Old Password Incorrect!!!";
                    return View("ChangePass");
                }
                else
                {
                    var newpass = Request["newpass"].ToString();
                    var repass = Request["renewpass"].ToString();
                    if (newpass.Equals(repass))
                    {
                        check.password = newpass;
                        _db.Configuration.ValidateOnSaveEnabled = false;
                        _db.SaveChanges();
                        ViewBag.err = "Change Pass successfully";
                    }
                    else
                    {
                        ViewBag.err = "New Password and Confirm New Password must be the same";
                        return View("ChangePass");
                    }
                }
            }
            return View();
        }

        [NonAction]
        public void sendResetLink(string EmailID, string resetCode)
        {
            var verifyUrl = "/Account/resetPassword/" + resetCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            
            var fromEmail = new MailAddress("???@gmai.com", "System Call");//nhap email o ???
            var toEmail = new MailAddress(EmailID);
            var fromPassword = "**********"; //nhap password 

            string subject = "Reset Password";
            string body = "Hi,<br/><br/>We got request for reset your Account password. Please click on the below link to reset your password" +
                "<br/><br/><a href="+link+">Reset Password link<a/>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address,fromPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            smtp.Send(message);
        }

        public ActionResult forgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult forgotPassword(string EmailID)
        {
            string message = "";
            bool status = false;
            //verify
            using(LAPTOP_ASPEntities context = new LAPTOP_ASPEntities())
            {
                var account = context.users.Where(a => a.email == EmailID).FirstOrDefault();
                if (account != null)
                {
                    //send email for reset
                    string resetCode = Guid.NewGuid().ToString();
                    sendResetLink(account.email, resetCode);
                    account.resetCode = resetCode;

                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.SaveChanges();
                    message = "Reset password link has been sent to your Email";
                }
                else
                {
                    message = "Account not found";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult resetPassword(string id)
        {
            //verify
            using(LAPTOP_ASPEntities context = new LAPTOP_ASPEntities())
            {
                var user = context.users.Where(a => a.resetCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.resetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult resetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (LAPTOP_ASPEntities context = new LAPTOP_ASPEntities())
                {
                    var user = context.users.Where(a => a.resetCode == model.resetCode).FirstOrDefault();
                    if(user != null)
                    {
                        user.password = model.newPassword;
                        user.resetCode = "";

                        context.Configuration.ValidateOnSaveEnabled = false;
                        context.SaveChanges();
                        message = "New Password update successfully";
                    }
                }
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return View(model);
        }
    }
}