using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingBasketDemo.Basket;

namespace ShoppingBasketDemo.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(ShoppingBasket basket)
        {
            //aaaaa
            var itemsInBasket = basket.GetAllItems();
            Console.WriteLine("Items:");
            foreach (var item in itemsInBasket)
            {
                Console.WriteLine(item.item.Name + ": " + item.Price + "$");
            }

            Console.WriteLine("Applied discounts:");
            var discounts = basket.GetAllDiscounts();
            foreach (var discount in discounts)
            {
                if (discount.nuberOfTimesApplied > 0)
                    Console.WriteLine(discount.name + ", applied " + discount.nuberOfTimesApplied + " time(s)");
            }

            Console.WriteLine("Total: " + itemsInBasket.Sum(i => i.Price) + "$");
        }
    }
}
