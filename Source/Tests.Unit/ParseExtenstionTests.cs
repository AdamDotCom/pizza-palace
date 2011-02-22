using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaPalace;
using PizzaPalace.Extensions;

namespace Tests.Unit
{
    [TestFixture]
    public class ParseExtensionTests
    {
        [Test]
        public void VerifyParseNumberOfPizzasWithPizzaCount()
        {
            Assert.AreEqual(2, "2 Large - Pepperoni, Cheese,".ParseNumberOfPizzas());
        }

        [Test]
        public void VerifyParseNumberOfPizzasWithoutPizzaCount()
        {
            Assert.AreEqual(1, "Large - Pepperoni, Cheese,".ParseNumberOfPizzas());
        }
        
        [Test]
        public void VerifyParseThreeToppings()
        {
            var result = "2 Large - Pepperoni, Cheese, Sausage,".ParseToppings();
            
            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.Contains("Cheese"));
            Assert.IsTrue(result.Contains("Pepperoni"));
            Assert.IsTrue(result.Contains("Sausage"));
            Assert.IsFalse(result.Contains("Ham"));
        }
        
        [Test]
        public void VerifyParseOneTopping()
        {
            var result = "Small - Cheese".ParseToppings();
            
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains("Cheese"));
        }
        
        [Test]
        public void VerifyParseSizeWithPizzaCount()
        {
            Assert.AreEqual(Size.Large, "2 Large - Ham".ParseSize());
        }
        
        [Test]
        public void VerifyParseSizeWithoutPizzaCount()
        {
            Assert.AreEqual(Size.Medium, "Medium - Pepperoni, Cheese,".ParseSize());
        }
        
        [Test]
        public void VerifyParseSizeWithoutPizzaCountAndMessedUpSize()
        {
            Assert.AreEqual(Size.Small, "SuperDuperLarge - Pepperoni, Cheese,".ParseSize());
        }
    }
}