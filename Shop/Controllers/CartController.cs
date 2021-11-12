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
        public List<CartItem> getCart()
        {
            List<CartItem> cartitems = Session["Cart"] as List<CartItem>;
            if(cartitems == null)
            {
                cartitems = new List<CartItem>();
                Session["Cart"] = cartitems;
            }
            return cartitems;
        }

        public ActionResult ShowToCart()
        {
            List<CartItem> cartitems = getCart();
            return View(cartitems);
        }

        public ActionResult AddToCart(int id)
        {
            var pro = _db.products.SingleOrDefault(s => s.id_pro == id);
          
            if(pro == null)
            {
                return null;
            }
            List<CartItem> cartitems = getCart();
            CartItem check = cartitems.SingleOrDefault(s => s.id_pro == id);
            if (check != null)
            {
                check._shopping_quantity++;
                return RedirectToAction("ShowToCart");
            }
            CartItem item = new CartItem(id);
            cartitems.Add(item);

            return RedirectToAction("ShowToCart");
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