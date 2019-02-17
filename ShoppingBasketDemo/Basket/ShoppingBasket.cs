using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingBasketDemo.Repo;
using ShoppingBasketDemo.Discounts;
using ShoppingBasketDemo.Logging;

namespace ShoppingBasketDemo.Basket
{
    public class ShoppingBasket
    {
        private List<ShoppingBasketItem> items;
        private List<IDiscount> discounts;
        private ILogger logger;

        public ShoppingBasket(ILogger log)
        {
            items = new List<ShoppingBasketItem>();
            discounts = new List<IDiscount>();
            logger = log;
        }

        public void AddToBasket(Item item)
        {
            items.Add(new ShoppingBasketItem(item));
        }

        public void RemoveFromBasket(int id)
        {
            ShoppingBasketItem itemToRemove = items.Where(i => i.item.Id == id)
                                                   .First();

            if (itemToRemove != null)
                items.Remove(itemToRemove);
        }

        public void AddDiscount(IDiscount discount)
        {
            if (discounts.Any(d => d.GetType() == discount.GetType()))
            {
                throw new Exception("Discount already exists!");
            }
            else
            {
                discounts.Add(discount);
            }
        }

        public List<ShoppingBasketItem> GetAllItems()
        {
            return this.items;
        }

        public List<IDiscount> GetAllDiscounts()
        {
            return this.discounts;
        }

        public double RequestTotal()
        {
            //when calculating new total, update item prices to originals..
            foreach (var item in items)
            {
                item.Price = item.item.Price;
            }
            //..apply discount(s)
            foreach (var discount in discounts)
            {
                discount.CalculateDiscount(this.items);
            }
            //..log to console
            logger.Log(this);

            //..return total
            return items.Sum(i => i.Price);
        }

    }
}
