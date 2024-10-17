using System;
using Application;

namespace GrosvenorInHousePracticum
{
    class Program
    {
        static void Main()
        {
            var server = new Server(new DishManager());

            Console.WriteLine("Enter your order in the following format: <timeOfDay>,<dishType1>,<dishType2>,...");

            while (true)
            {
                try
                {
                    var unparsedOrder = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(unparsedOrder))
                    {
                        Console.WriteLine("Please enter a valid order.");
                        continue;
                    }

                    var output = server.TakeOrder(unparsedOrder);
                    Console.WriteLine(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
        }
    }
}
