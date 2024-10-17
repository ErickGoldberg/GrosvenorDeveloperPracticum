using System;

namespace GrosvenorDeveloperPracticum.Domain.Entities
{
    /// <summary>
    /// Contains a dish by name and number of times the dish has been ordered
    /// </summary>
    public class Dish
    {
        private string _dishName;
        private int _count;

        public Dish(string dishName, int count)
        {
            if (string.IsNullOrWhiteSpace(dishName))
                throw new ArgumentException("Dish name cannot be empty.", nameof(dishName));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative.");

            _dishName = dishName;
            _count = count;
        }

        public string DishName
        {
            get => _dishName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Dish name cannot be empty.", nameof(value));

                _dishName = value;
            }
        }

        public int Count
        {
            get => _count;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Count cannot be negative.");
                _count = value;
            }
        }

        public void IncrementCount(int amount = 1)
        {
            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Increment amount must be positive.");

            Count += amount;
        }

        public void DecrementCount(int amount = 1)
        {
            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Decrement amount must be positive.");

            if (_count - amount < 0)
                throw new InvalidOperationException("Count cannot be negative.");

            Count -= amount;
        }
    }
}