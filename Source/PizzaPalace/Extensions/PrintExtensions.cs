using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Extensions
{
    public static class OrderExtensions
    {
        public static string Print(this Order order)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in order.Items)
            {
                builder.AppendLine(string.Format("{0}: {1}", item.Description, item.Price.ToString("C")));
            }        
            builder.AppendLine();        
            builder.AppendLine(string.Format("Subtotal: {0}", order.SubTotal.ToString("C")));
            
            string taxNames = string.Empty;
            foreach (var item in order.Taxes)
            {
                taxNames = taxNames + item.Name;
            }   
            
            builder.AppendLine(string.Format("{0}: {1}", taxNames, order.Tax.ToString("C")));
            builder.AppendLine(string.Format("Total: {0}", order.Total.ToString("C")));
            
            return builder.ToString();
        }
    }
}