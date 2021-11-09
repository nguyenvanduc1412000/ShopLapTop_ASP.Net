using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class CartItem
    {
        public product _shopping_product { get; set; }
        public int _shopping_quantity { get; set; }
    }

    //Gio hang
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }

        }
        public void Add(product _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._shopping_product.id_pro == _pro.id_pro);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _shopping_product = _pro,
                    _shopping_quantity = _quantity
                });
            }
            else
            {
                item._shopping_quantity += _quantity;
            }
        }

        public void Update_Quantity_Shopping(int id, int _quantity)
        {
            var item = items.Find(s => s._shopping_product.id_pro == id);
            if (item != null) 
            {
                item._shopping_quantity = _quantity;
            }
           
        }
    }
}