using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalace.Extensions
{
    public static class FormatExtensions
    {
        public static string Description(int count, List<string> toppings, Size size)
        {
            return string.Format("{0} {1}, {2} Topping Pizza - {3}", count, size, toppings.Count.ToHumanReadable(), toppings.AddPunctuation(), size);
        }
        
        public static string AddPunctuation(this List<string> value)
        {
            var delimiter = ", ";
            var result = string.Join(delimiter, (from i in value select i.UppercaseFirst()).ToArray());
            
            int lastPos = result.LastIndexOf(delimiter);
            
            if (lastPos != -1){
                return result.Substring(0, lastPos) + " and " + result.Substring(lastPos + delimiter.Length, result.Length - lastPos - delimiter.Length);    
            }
            
            return result;
        }
        
        public static string UppercaseFirst(this string value)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(value[0]) + value.Substring(1);
        }
        
        public static string ToHumanReadable(this int value)
        {
            switch (value) 
            {
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";                    
                default:
                    return string.Empty;
            }
        }
    }
}