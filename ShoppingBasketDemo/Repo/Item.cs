using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDemo.Repo
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Item(int id, string Name, double price)
        {
            this.Id = id;
            this.Name = Name;
            this.Price = price;
        }

    }
}
