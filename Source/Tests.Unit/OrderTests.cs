using System;
using NUnit.Framework;
using PizzaPalace;
using PizzaPalace.Extensions;

namespace Tests.Unit
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void VerifyNewOrder()
        {
            try
            {
                var order = new Order();
            } 
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Unexpected exception was thrown: {0}", ex.ToString()));
            }
        }
        
        [Test]
        public void VerifyOrderSubTotal()
        {
            var order = new Order();
            order.Items.Add(new OrderItem() { Price = 18m });
            order.Items.Add(new OrderItem() { Price = 15.5m });
            order.Items.Add(new OrderItem() { Price = 13m });
            
            Assert.AreEqual(46.50m, order.SubTotal);
        }

        [Test]
        public void VerifyOrderTaxes()
        {
            var order = new Order();
            order.Items.Add(new OrderItem() { Price = 18m });
            order.Items.Add(new OrderItem() { Price = 15.5m });
            order.Items.Add(new OrderItem() { Price = 13m });
            order.Taxes.Add(new TaxItem() { Rate = .05 });
            
            Assert.AreEqual(2.33m, order.Tax);
        }
        
        [Test]
        public void VerifyOrderTotal()
        {
            var order = new Order();
            order.Items.Add(new OrderItem() { Price = 18m });
            order.Items.Add(new OrderItem() { Price = 15.5m });
            order.Items.Add(new OrderItem() { Price = 13m });
            order.Taxes.Add(new TaxItem() { Rate = .05 });
            
            Assert.AreEqual(48.83m, order.Total);
        }
    }
}