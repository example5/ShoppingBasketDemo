using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingBasketDemo.Basket;

namespace ShoppingBasketDemo.Discounts
{
    public class BreadAt50Percent : IDiscount
    {
        public string name { get; set; } = "Bread at 50% off";
        public int nuberOfTimesApplied { get; set; }
        

        public void CalculateDiscount(List<ShoppingBasketItem> items)
        {
            nuberOfTimesApplied = 0;

            int totalButtersInBasket = items.Where(i => i.item.Name == "Butter")
                                            .Count();

            int totalBreadsForDiscount = totalButtersInBasket / 2;

            var breadsInBasket = items.Where(i => i.item.Name == "Bread")
                                      .ToList();

            foreach (var bread in breadsInBasket)
            {
                if (totalBreadsForDiscount > 0)
                {
                    bread.Price /= 2;
                    totalBreadsForDiscount--;
                    nuberOfTimesApplied++;
                }
            }
        }
    }
}
