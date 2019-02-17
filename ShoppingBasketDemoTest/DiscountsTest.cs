using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ShoppingBasketDemo.Repo;
using ShoppingBasketDemo.Basket;
using ShoppingBasketDemo.Discounts;
using ShoppingBasketDemo.Logging;

namespace ShoppingBasketDemoTest
{
    [TestClass]
    public class DiscountsTest
    {
        [TestMethod]
        public void Test_NoDiscount()
        {
            double expected = 2.95;

            var repo = new ItemsRepo();
            var repoItems = repo.GetAllItems();

            var basket = new ShoppingBasket(new ConsoleLogger());
            basket.AddDiscount(new BreadAt50Percent());
            basket.AddToBasket(repoItems.Find(i => i.Id == 1));//butter
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 3));//bread
            
            Assert.AreEqual(expected, basket.RequestTotal(), 0.01);
        }

        [TestMethod]
        public void Test_BreadAt50PercentDiscount()
        {
            double expected = 3.10;

            var repo = new ItemsRepo();
            var repoItems = repo.GetAllItems();

            var basket = new ShoppingBasket(new ConsoleLogger());
            basket.AddDiscount(new BreadAt50Percent());
            basket.AddToBasket(repoItems.Find(i => i.Id == 1));//butter
            basket.AddToBasket(repoItems.Find(i => i.Id == 1));//butter
            basket.AddToBasket(repoItems.Find(i => i.Id == 3));//bread
            basket.AddToBasket(repoItems.Find(i => i.Id == 3));//bread

            Assert.AreEqual(expected, basket.RequestTotal(), 0.01);
        }

        [TestMethod]
        public void Test_FreeMilkDiscount()
        {
            double expected = 3.45;

            var repo = new ItemsRepo();
            var repoItems = repo.GetAllItems();

            var basket = new ShoppingBasket(new ConsoleLogger());
            basket.AddDiscount(new FreeMilk());
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk

            Assert.AreEqual(expected, basket.RequestTotal(), 0.01);
        }

        [TestMethod]
        public void Test_MultipleDiscount()
        {
            double expected = 9;

            var repo = new ItemsRepo();
            var repoItems = repo.GetAllItems();

            var basket = new ShoppingBasket(new ConsoleLogger());
            basket.AddDiscount(new BreadAt50Percent());
            basket.AddDiscount(new FreeMilk());
            basket.AddToBasket(repoItems.Find(i => i.Id == 1));//butter
            basket.AddToBasket(repoItems.Find(i => i.Id == 1));//butter
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 2));//milk
            basket.AddToBasket(repoItems.Find(i => i.Id == 3));//bread
            
            Assert.AreEqual(expected, basket.RequestTotal(), 0.01);
        }
    }
}
