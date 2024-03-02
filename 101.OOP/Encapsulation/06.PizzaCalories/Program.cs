using PizzaCalories.Models;
using System.ComponentModel;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string pizzaName = Console.ReadLine().Split(" ")[1];
                string[] doughParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Dough dough = new Dough(doughParams[1], doughParams[2], double.Parse(doughParams[3]));
                Pizza pizza = new Pizza(pizzaName, dough);

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Topping topping = new Topping(inputArg[1], double.Parse(inputArg[2]));
                    pizza.AddTopping(topping);                    
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message);

            }


                
            
        }
    }
}