using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDemo.Repo
{
    public class ItemsRepo
    {
        private List<Item> itemsList;

        public ItemsRepo()
        {
            itemsList = new List<Item>()
            {
                new Item(1, "Butter", 0.8),
                new Item(2, "Milk", 1.15),
                new Item(3, "Bread", 1),
            };
        }

        public List<Item> GetAllItems()
        {
            return itemsList;
        }

        public Item GetItemById(int id)
        {
            Item item = itemsList.Where(i => i.Id == id).First();

            if (item == null)
            {
                throw new Exception("Item not found!");
            }
            else
            {
                return item;
            }
        }

    }
}
