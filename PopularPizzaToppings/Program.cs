using Newtonsoft.Json;
using System.Collections.Generic;

namespace PopularPizzaToppings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Retrieve
            List<Pizza> pizzas = JsonConvert.DeserializeObject<List<Pizza>>(Toppings.GetToppings());

            //Process
            Dictionary<string, int> popularToppings = Toppings.ProcessToppings(pizzas);

            //Display
            Toppings.DisplayToppings(popularToppings, 20);
        }
    }
}
