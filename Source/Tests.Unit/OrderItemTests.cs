using System;
using NUnit.Framework;
using PizzaPalace;

namespace Tests.Unit
{
    [TestFixture]
    public class OrderItemTests
    {
        [Test]
        public void VerifyNewOrderItem()
        {
            var itemDesc = "1 Large, Two Topping Pizza - Pepperoni and Cheese";
            var price = 18m;
            var orderItem = new OrderItem() { Description = itemDesc, Price = price };
            
            Assert.AreEqual(price, orderItem.Price);
            Assert.AreEqual(itemDesc, orderItem.Description);
        }
    }
}
