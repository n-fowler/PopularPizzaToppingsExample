using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace PopularPizzaToppings
{
    public static class Toppings
    {
        private static string toppingsUri = "http://files.olo.com/pizzas.json";

        public static string GetToppings()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(toppingsUri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    if (stream == null) return null;

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        public static Dictionary<string, int> ProcessToppings(List<Pizza> pizzas)
        {
            Dictionary<string, int> popularToppings = new Dictionary<string, int>();

            foreach (Pizza pizza in pizzas)
            {
                pizza.toppings.Sort();

                string toppingsKey = string.Join(",", pizza.toppings);

                if (!popularToppings.ContainsKey(toppingsKey))
                {
                    popularToppings.Add(toppingsKey, 1);
                }
                else
                {
                    popularToppings[toppingsKey] += 1;
                }
            }

            return popularToppings;
        }

        public static void DisplayToppings(Dictionary<string, int> popularToppings, int displayQuantity)
        {
            IEnumerable<KeyValuePair<string, int>> mostPopularToppingCombinations = popularToppings.OrderByDescending(key => key.Value).Take(displayQuantity);

            int count = 0;
            foreach (KeyValuePair<string, int> mostPopularToppingCombination in mostPopularToppingCombinations)
            {
                Console.WriteLine($"Rank: [{++count}] Toppings: [{mostPopularToppingCombination.Key}] Times Ordered: [{mostPopularToppingCombination.Value}] ");
            }

            Console.ReadLine();
        }
    }
}
