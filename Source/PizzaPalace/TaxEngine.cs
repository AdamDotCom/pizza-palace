using System;
using System.Collections.Generic;

namespace PizzaPalace
{
    public class TaxEngine
    {
        public List<TaxItem> Taxes { get; set; }
        
        public TaxEngine() : this(new List<TaxItem>() { new TaxItem() { Name = "GST", Rate = .05 }}) 
        {
        }
        
        public TaxEngine(List<TaxItem> taxes)
        {
            Taxes = taxes;
        }
    }
}