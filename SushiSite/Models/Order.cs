using System.Collections.Generic;

namespace SushiSite.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public IEnumerable<Food> Foods { get; set; }

    }
}
