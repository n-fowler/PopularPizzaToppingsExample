using Newtonsoft.Json;
using System.Collections.Generic;

namespace PopularPizzaToppings
{
    public class Pizza
    {
        [JsonProperty("toppings")]
        public List<string> toppings { get; set; }
    }
}
