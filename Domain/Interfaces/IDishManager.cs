using System.Collections.Generic;
using GrosvenorDeveloperPracticum.Domain.Entities;

namespace GrosvenorDeveloperPracticum.Domain.Interfaces
{

    public interface IDishManager
    {
        /// <summary>
        /// Constructs a list of dishes, each dish with a name and a count
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        List<Dish> GetDishes(Order order);
    }
}