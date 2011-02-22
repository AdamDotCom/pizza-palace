using System;
using System.Collections.Generic;

namespace PizzaPalace
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
            Taxes = new List<TaxItem>();
        }
        
        public List<OrderItem> Items { get; set; }        
        public List<TaxItem> Taxes { get; set; }
        
        public decimal SubTotal { 
            get 
            { 
                decimal result = 0;
                foreach (var item in Items)
                {
                    result += item.Price;
                }
                return result;
            }
        }
        
        public decimal Total { 
            get
            {
                return SubTotal + Tax;
            }
        }
        
        public decimal Tax { 
            get
            {
                double result = 0;
                foreach (var tax in Taxes)
                {
                    result += tax.Rate;
                }
                return Decimal.Round(Convert.ToDecimal(result) * SubTotal * 100 + .5m, 2) / 100;
            }
        }
    }
}

