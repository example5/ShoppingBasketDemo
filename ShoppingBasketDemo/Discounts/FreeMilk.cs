using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingBasketDemo.Basket;

namespace ShoppingBasketDemo.Discounts
{
    public class FreeMilk : IDiscount
    {
        public string name { get; set; } = "Free milk";

        public int nuberOfTimesApplied { get; set; }

        public void CalculateDiscount(List<ShoppingBasketItem> items)
        {
            nuberOfTimesApplied = 0;

            int totalMilksInBasket = items.Where(i => i.item.Name == "Milk")
                                            .Count();

            int totalFreeMilks = totalMilksInBasket / 4;

            var milksInBasket = items.Where(i => i.item.Name == "Milk")
                                      .ToList();

            foreach (var milk in milksInBasket)
            {
                if (totalFreeMilks > 0)
                {
                    milk.Price = 0;
                    totalFreeMilks--;
                    nuberOfTimesApplied++;
                }
            }
        }
    }
}
