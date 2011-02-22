using System;
using System.Collections.Generic;
using PizzaPalace.Extensions;

namespace PizzaPalace
{
    public class PizzaApplication
    {
        private static Order order;
        private static PriceEngine priceEngine;
        private static TaxEngine taxEngine;
        
        static PizzaApplication()
        {
            order = new Order();
            priceEngine = new PriceEngine();
            taxEngine = new TaxEngine();
        }
        
        static int Main() 
        {
            try 
            {
                string inputText;
                
                Console.WriteLine("Place your pizza order (or press the Enter key to stop):");
                do 
                { 
                    inputText = Console.ReadLine();
                    
                    if (inputText.Length != 0)
                    {
                        try 
                        {
                            Process(inputText);    
                        }
                        catch (Exception ex)
                        { 
                            Console.WriteLine();
                            Console.WriteLine("Invalid input, enter orders in the form of: number size - toppings, toppings, ... ");
                            Console.WriteLine("Example: 2 Large - Ham, Cheese, Sausage");
                            Console.WriteLine();
                        }                                                
                    }
                    
                } while (inputText.Length != 0);
                
                order.Taxes = taxEngine.Taxes;
                
                Console.WriteLine(Print());
                                
                return 1;    
            }
            catch
            { 
                return 0;
            }
        }
 
        static void Process(string rawInput)
        {
            int numberOfPizzas = rawInput.ParseNumberOfPizzas();
            List<string> toppings = rawInput.ParseToppings();
            Size size = rawInput.ParseSize();
            
            order.Items.Add(new OrderItem() {
                                              Price = priceEngine.Price(numberOfPizzas, toppings, size),
                                              Description = FormatExtensions.Description(numberOfPizzas, toppings, size)
                                             });
        }
        
        static string Print(){
            return order.Print();
        }       
    }
}