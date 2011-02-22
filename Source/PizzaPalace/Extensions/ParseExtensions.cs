using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalace.Extensions
{
    public static class ParseExtensions
    {
        public static int ParseNumberOfPizzas(this string value)
        {
            var split = value.Split(' ');
            
            int result;
            if (!Int32.TryParse(split[0], out result))
            {
                return 1;
            }
            
            return result;
        }
        
        public static List<string> ParseToppings(this string value)
        {
            var result = new List<string>();
            
            var delimiter = "-";
            var substring = value.Substring(value.IndexOf(delimiter) + delimiter.Length, value.Length - (value.IndexOf(delimiter) + delimiter.Length));
            
            var split = substring.Split(',');
            foreach(var item in split)
            {
                if (item.Trim().Length > 0)
                {
                    result.Add(item.Trim());
                }
            }
            return result;
        }
        
        public static Size ParseSize(this string value)
        {
            var split = value.Split(' ');
            
            int result;
            if (Int32.TryParse(split[0], out result))
            {
                return split[1].Convert();
            }

            return split[0].Convert();
        }
        
        public static Size Convert(this string value)
        {
            try 
            {
                return (Size) Enum.Parse(typeof(Size), value, true);
            }
            catch 
            {
                return Size.Small;
            }
        }
    }
}