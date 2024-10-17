using System;
using System.Collections.Generic;

namespace Application
{
    public class Server : IServer
    {
        private readonly IDishManager _dishManager;

        public Server(IDishManager dishManager)
        {
            _dishManager = dishManager;
        }

        public string TakeOrder(string unparsedOrder)
        {
            try
            {
                var order = ParseOrder(unparsedOrder);
                var dishes = _dishManager.GetDishes(order);
                var returnValue = FormatOutput(dishes);
                return returnValue;
            }
            catch (ApplicationException)
            {
                return "error";
            }
        }

        private Order ParseOrder(string unparsedOrder)
        {
            var returnValue = new Order
            {
                Dishes = new List<int>()
            };

            var orderItems = unparsedOrder.Split(',');
            var period = orderItems[0].Trim().ToLower();  

            if (period != "morning" && period != "evening")
            {
                throw new ApplicationException("Invalid period. Must be 'morning' or 'evening'.");
            }

            returnValue.Period = period;

            for (var i = 1; i < orderItems.Length; i++)
            {
                if (int.TryParse(orderItems[i], out var parsedOrder))
                {
                    returnValue.Dishes.Add(parsedOrder);
                }
                else
                {
                    throw new ApplicationException("Order needs to be a comma-separated list of numbers.");
                }
            }

            return returnValue;
        }

        private string FormatOutput(List<Dish> dishes)
        {
            var returnValue = "";

            foreach (var dish in dishes)
            {
                returnValue += $",{dish.DishName}{GetMultiple(dish.Count)}";
            }

            if (returnValue.StartsWith(","))
                returnValue = returnValue.TrimStart(',');

            return returnValue;
        }

        private object GetMultiple(int count)
        {
            if (count > 1)
                return $"(x{count})";
            
            return "";
        }
    }
}
