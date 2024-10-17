using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DishManager : IDishManager
    {
        public List<Dish> GetDishes(Order order)
        {
            var returnValue = new List<Dish>();
            order.Dishes.Sort();

            foreach (var dishType in order.Dishes)
            {
                AddOrderToList(dishType, returnValue, order.Period); 
            }

            return returnValue;
        }

        private void AddOrderToList(int dishType, List<Dish> returnValue, string period)
        {
            var orderName = GetOrderName(dishType, period);
            var existingOrder = returnValue.SingleOrDefault(x => x.DishName == orderName);

            if (existingOrder == null)
            {
                returnValue.Add(new Dish
                {
                    DishName = orderName,
                    Count = 1
                });
            }
            else if (IsMultipleAllowed(dishType, period))
            {
                existingOrder.Count++;
            }
            else
            {
                throw new ApplicationException($"Multiple {orderName}(s) not allowed");
            }
        }

        private string GetOrderName(int dishType, string period)
        {
            if (string.Equals(period, "morning", StringComparison.OrdinalIgnoreCase))
            {
                switch (dishType)
                {
                    case 1:
                        return "egg";
                    case 2:
                        return "toast";
                    case 3:
                        return "coffee";
                    default:
                        throw new ApplicationException("Invalid dish for morning.");
                }
            }

            if (string.Equals(period, "evening", StringComparison.OrdinalIgnoreCase))
            {
                switch (dishType)
                {
                    case 1:
                        return "steak";
                    case 2:
                        return "potato";
                    case 3:
                        return "wine";
                    case 4:
                        return "cake";
                    default:
                        throw new ApplicationException("Invalid dish for evening.");
                }
            }

            throw new ApplicationException("Invalid period.");
        }

        private bool IsMultipleAllowed(int dishType, string period)
        {
            if (string.Equals(period, "morning", StringComparison.OrdinalIgnoreCase) && dishType == 3)
                return true;

            if (string.Equals(period, "evening", StringComparison.OrdinalIgnoreCase) && dishType == 2)
                return true;

            return false;
        }
    }

}