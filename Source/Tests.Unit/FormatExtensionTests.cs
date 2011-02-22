using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaPalace;
using PizzaPalace.Extensions;

namespace Tests.Unit
{
    [TestFixture]
    public class FormatExtensionTests
    {
        [Test]
        public void VerifyDescriptionFormatWithPizzaCount()
        {            
            var description = FormatExtensions.Description(2, new List<string>() { "Pepperoni", "Cheese" }, Size.Large);
            
            Assert.AreEqual("2 Large, Two Topping Pizza - Pepperoni and Cheese", description);
        }
                
        [Test]
        public void VerifyDescriptionFormatWithLowercaseToppings()
        {            
            var description = FormatExtensions.Description(1, new List<string>() { "pepperoni", "feta Cheese", "ham"}, Size.Medium);
            
            Assert.AreEqual("1 Medium, Three Topping Pizza - Pepperoni, Feta Cheese and Ham", description);
        }        

    }
}
