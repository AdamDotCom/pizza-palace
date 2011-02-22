using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaPalace;
using PizzaPalace.Extensions;

namespace Tests.Unit
{
    [TestFixture]
    public class PrintExtensionTests
    {
        [Test]
        public void VerifyOrderItemFormat()
        {
            var desc = "something-something";
            var taxName = "GST";
            
            var order = new Order();
            order.Items.Add(new OrderItem() { Price = 18m, Description = desc });
            order.Items.Add(new OrderItem() { Price = 15.5m });
            order.Items.Add(new OrderItem() { Price = 13m });
            order.Taxes.Add(new TaxItem() { Rate = .05, Name = taxName });
            
            Console.WriteLine();
            Console.WriteLine("-----------");
            Console.WriteLine(order.Print());
            Console.WriteLine("-----------");
            
            Assert.IsTrue(order.Print().Contains(desc));
            Assert.IsTrue(order.Print().Contains(taxName));
            Assert.IsTrue(order.Print().Contains("Subtotal: $46.5"));
            Assert.IsTrue(order.Print().Contains("GST: $2.33"));
            Assert.IsTrue(order.Print().Contains("Total: $48.83"));
        }
    }
}