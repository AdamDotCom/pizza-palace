using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaPalace;

namespace Tests.Unit
{
    [TestFixture]
    public class TaxEngineTests
    {
        [Test]
        public void VerifyAddTax()
        {
            var taxRate = .05;
            var taxName = "GST";
            
            var taxes = new List<TaxItem>() { new TaxItem() { Name = taxName, Rate = taxRate }};
            var taxEngine = new TaxEngine(taxes);
            
            Assert.IsNotNull(taxEngine.Taxes);
            Assert.IsTrue(taxEngine.Taxes.Count == 1);
            Assert.AreEqual(taxRate, taxEngine.Taxes[0].Rate);
            Assert.AreEqual(taxName, taxEngine.Taxes[0].Name);
        }        
    }
}