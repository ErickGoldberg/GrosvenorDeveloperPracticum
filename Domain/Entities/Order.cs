using System;
using System.Collections.Generic;

namespace GrosvenorDeveloperPracticum.Domain.Entities
{
    public class Order
    {
        private List<int> _dishes;

        public Order()
        {
            _dishes = new List<int>();
        }

        public string Period { get; private set; }

        public IReadOnlyList<int> Dishes => _dishes.AsReadOnly();

        public void SetPeriod(string period)
        {
            if (!period.Equals("morning", StringComparison.OrdinalIgnoreCase) &&
                !period.Equals("evening", StringComparison.OrdinalIgnoreCase))
            {
                throw new ApplicationException("Invalid period. Must be 'morning' or 'evening'.");
            }

            Period = period.ToLower();
        }

        public void AddDish(int dish)
        {
            _dishes.Add(dish);
        }

        public void SortDishes()
        {
            _dishes.Sort();
        }
    }
}