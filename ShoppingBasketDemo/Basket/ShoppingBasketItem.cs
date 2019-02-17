using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingBasketDemo.Repo;

namespace ShoppingBasketDemo.Basket
{
    public class ShoppingBasketItem
    {
        public Item item;
        public double Price { get; set; }

        public ShoppingBasketItem(Item item)
        {
            this.item = item;
            this.Price = item.Price;
        }
    }
}
