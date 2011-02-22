using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalace
{
    public class PriceEngine
    {
        private List<PizzaSize> pricedSizes;
        private List<PizzaTopping> pricedToppings;
        
        public PriceEngine() : this(LoadPricedPizzaToppings(), LoadPricedPizzaSizes())
        {
        }
        
        public PriceEngine(List<PizzaTopping> pricedToppings, List<PizzaSize> pricedSizes)
        {
            this.pricedToppings = pricedToppings;
            this.pricedSizes = pricedSizes;
        }
        
        public decimal Price(int count, List<string> toppings, Size size)
        {            
            var pricedSize = pricedSizes.Where(s => s.Size == size).FirstOrDefault();
            var sizePrice = 0m;
            if (pricedSize != null)
            {
                sizePrice = pricedSize.Price;    
            }
            
            var toppingPrices = 0m;
            foreach(var topping in toppings)
            {
                var pricedTopping = pricedToppings.Where(t => t.Name.ToLower() == topping.ToLower() && t.Size == size).FirstOrDefault();
                if (pricedTopping != null)
                {
                    toppingPrices += pricedTopping.Price;
                }
            }
            
            if (toppingPrices == 0m || sizePrice == 0m){
                throw new Exception("Pricing could not be found");
            }
            
            return (sizePrice + toppingPrices) * count;
        }
        
                
        public static List<PizzaSize> LoadPricedPizzaSizes()
        {
            return new List<PizzaSize>() { 
                                           new PizzaSize() { Size = Size.Small, Price = 12 },
                                           new PizzaSize() { Size = Size.Medium, Price = 14 },
                                           new PizzaSize() { Size = Size.Large, Price = 16 }
                                         };            
        }
        
        public static List<PizzaTopping> LoadPricedPizzaToppings() 
        {
            return new List<PizzaTopping>() { 
                                              new PizzaTopping() { Name = "Cheese", Price = .5m, Size = Size.Small }, 
                                              new PizzaTopping() { Name = "Cheese", Price = .75m, Size = Size.Medium },
                                              new PizzaTopping() { Name = "Cheese", Price = 1m, Size = Size.Large },
                                              new PizzaTopping() { Name = "Pepperoni", Price = .5m, Size = Size.Small }, 
                                              new PizzaTopping() { Name = "Pepperoni", Price = .75m, Size = Size.Medium },
                                              new PizzaTopping() { Name = "Pepperoni", Price = 1m, Size = Size.Large },
                                              new PizzaTopping() { Name = "Ham", Price = .5m, Size = Size.Small }, 
                                              new PizzaTopping() { Name = "Ham", Price = .75m, Size = Size.Medium },
                                              new PizzaTopping() { Name = "Ham", Price = 1m, Size = Size.Large },
                                              new PizzaTopping() { Name = "Pineapple", Price = .5m, Size = Size.Small }, 
                                              new PizzaTopping() { Name = "Pineapple", Price = .75m, Size = Size.Medium },
                                              new PizzaTopping() { Name = "Pineapple", Price = 1m, Size = Size.Large },
                                              new PizzaTopping() { Name = "Sausage", Price = 2m, Size = Size.Small }, 
                                              new PizzaTopping() { Name = "Sausage", Price = 3m, Size = Size.Medium },
                                              new PizzaTopping() { Name = "Sausage", Price = 4m, Size = Size.Large },
                                              new PizzaTopping() { Name = "Feta Cheese", Price = 2m, Size = Size.Small }, 
                                              new PizzaTopping() { Name = "Feta Cheese", Price = 3m, Size = Size.Medium },
                                              new PizzaTopping() { Name = "Feta Cheese", Price = 4m, Size = Size.Large },
                                              new PizzaTopping() { Name = "Tomatoes", Price = 2m, Size = Size.Small }, 
                                              new PizzaTopping() { Name = "Tomatoes", Price = 3m, Size = Size.Medium },
                                              new PizzaTopping() { Name = "Tomatoes", Price = 4m, Size = Size.Large },
                                              new PizzaTopping() { Name = "Olives", Price = 2m, Size = Size.Small },
                                              new PizzaTopping() { Name = "Olives", Price = 3m, Size = Size.Medium },
                                              new PizzaTopping() { Name = "Olives", Price = 4m, Size = Size.Large },
                                            };
        }
    }
}