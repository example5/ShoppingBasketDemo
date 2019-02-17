using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingBasketDemo.Basket;

namespace ShoppingBasketDemo.Discounts
{

    public interface IDiscount
    {
        string name { get; set; }
        int nuberOfTimesApplied { get; set; }
        void CalculateDiscount(List<ShoppingBasketItem> items);
    }
}
