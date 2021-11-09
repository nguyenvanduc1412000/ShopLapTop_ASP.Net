using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace ProjectCSharps.Controllers
{
    public class CartController : Controller
    {
        LAPTOP_ASPEntities _db = new LAPTOP_ASPEntities();
        // GET: Cart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        // add items vaof gio hang
        public ActionResult AddtoCart(int id)
        {
            var pro = _db.products.SingleOrDefault(s => s.id_pro == id);
                if (pro != null)
                {
                    GetCart().Add(pro);

                }
            
            return View();
        }

        //trang gio hang
        public ActionResult ShowToCart()
        {
            if(Session["Cart"] == null)
            {
                return RedirectToAction("ShowToCart", "Cart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int ID_Pro = int.Parse(form["id_pro"]);
            int Quantity = int.Parse(form["quantity"]);
            cart.Update_Quantity_Shopping(ID_Pro, Quantity);
            return RedirectToAction("ShowToCart", "Cart");
        }

    }
}