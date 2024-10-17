using System.Collections.Generic;

namespace Application
{
    public class Order
    {
        public Order()
        {
            Dishes = new List<int>();
        }

        public string Period { get; set; } 
        public List<int> Dishes { get; set; }
    }

}