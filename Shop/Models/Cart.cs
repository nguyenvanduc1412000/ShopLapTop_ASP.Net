using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Models;
namespace Shop.Models
{
    public class CartItem
    {
        public int id_pro { get; set; }
        public Nullable<int> id_cat { get; set; }
        public string name_pro { get; set; }
        public string images { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<double> price { get; set; }
        public string supplier { get; set; }
        public string infor { get; set; }
        public Nullable<int> sell_ID { get; set; }
        public int _shopping_quantity { get; set; }

        public CartItem()
        {
        }
        public CartItem(int id, int _quantity = 1)
        {
            using (LAPTOP_ASPEntities _db = new LAPTOP_ASPEntities()) {
                this.id_pro = id;
                product p = _db.products.Single(s => s.id_pro == id);
                this.name_pro = p.name_pro;
                this.images = p.images;
                
                this.quantity = p.quantity;
                this.price = p.price;
                this.supplier = p.supplier;
                this.infor = p.infor;
                this.sell_ID = p.sell_ID;
                _shopping_quantity = _quantity;
                

            } 
        }
     
    }

    //Gio hang
    public class Cart
    {

        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
            set { value = items; }

        }


        public void Add(product _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.id_pro == _pro.id_pro);

            if (item == null)
            {
                items.Add(new CartItem
                {
                    id_pro = _pro.id_pro,
                    name_pro = _pro.name_pro,
                    images = _pro.images,
                    quantity = _pro.quantity,
                    price = _pro.price,
                    supplier= _pro.supplier,
                    infor = _pro.infor,
                    sell_ID = _pro.sell_ID,
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
            var item = items.Find(s => s.id_pro == id);
            if (item != null) 
            {
                item._shopping_quantity = _quantity;
            }
           
        }
    }
}