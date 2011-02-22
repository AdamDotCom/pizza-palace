using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaPalace;

namespace Tests.Unit
{
    [TestFixture]
    public class PriceEngineTests
    {
        [Test]
        public void VerifyPriceCalculations()
        {
            var sizePrice = 12m;
            var toppingPrice = .5m;
            var numberOfPizzas = 2;
            
            var pricedPizzaSizes = new List<PizzaSize>() { new PizzaSize() { Size = Size.Small, Price = sizePrice } };
            var pricedPizzaToppings = new List<PizzaTopping>() { new PizzaTopping() { Name = "Cheese", Price = toppingPrice, Size = Size.Small } };
            
            var priceEngine = new PriceEngine(pricedPizzaToppings, pricedPizzaSizes);
            var price = priceEngine.Price(numberOfPizzas, new List<string>() { "Cheese" }, Size.Small);
            
            Assert.AreEqual(((sizePrice + toppingPrice) * numberOfPizzas), price);
        }
        
        [Test, ExpectedException(typeof(Exception))]
        public void VerifyExceptionOnInvalidTopping()
        {
            var pricedPizzaSizes = new List<PizzaSize>() { new PizzaSize() { Size = Size.Small } };
            var pricedPizzaToppings = new List<PizzaTopping>() { new PizzaTopping() { Name = "Cheese", Size = Size.Small } };
            
            var priceEngine = new PriceEngine(pricedPizzaToppings, pricedPizzaSizes);
            var price = priceEngine.Price(1, new List<string>() { "Orange Juice" }, Size.Small);
        }
    }
}