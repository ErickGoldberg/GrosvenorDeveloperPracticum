using System;
using System.Collections.Generic;
using System.Linq;
using GrosvenorDeveloperPracticum.Domain.Entities;
using GrosvenorDeveloperPracticum.Domain.Interfaces;

namespace GrosvenorDeveloperPracticum.Application
{
    public class DishManager : IDishManager
    {
        public List<Dish> GetDishes(Order order)
        {
            var returnValue = new List<Dish>();
            order.SortDishes();

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
                var newDish = new Dish(orderName, 1);
                returnValue.Add(newDish);
            }
            else if (IsMultipleAllowed(dishType, period))
            {
                existingOrder.IncrementCount();
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