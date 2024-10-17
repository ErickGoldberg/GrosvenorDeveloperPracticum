using System;
using System.Collections.Generic;
using GrosvenorDeveloperPracticum.Configurations;
using GrosvenorDeveloperPracticum.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GrosvenorDeveloperPracticum
{
    class Program
    {
        static void Main()
        {
            var serviceProvider = ServiceConfigurator.ConfigureServices();
            var server = serviceProvider.GetService<IServer>();
            var orderHistory = new List<string>();

            Console.WriteLine("Welcome to the Order System!");
            Console.WriteLine("Enter your order in the following format: <timeOfDay>,<dishType1>,<dishType2>,...");
            Console.WriteLine("Type 'help' for instructions or 'exit' to quit.");

            while (true)
            {
                try
                {
                    var unparsedOrder = Console.ReadLine();

                    // Exit command
                    if (unparsedOrder.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Thank you for using.");
                        break;
                    }

                    // Help command
                    if (unparsedOrder.Equals("help", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Instructions:");
                        Console.WriteLine("1. Enter your order as <timeOfDay>,<dishType1>,<dishType2>,...");
                        Console.WriteLine("2. Time of day should be 'morning' or 'evening'.");
                        Console.WriteLine("3. Dish types should be separated by commas.");
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(unparsedOrder))
                    {
                        Console.WriteLine("Please enter a valid order.");
                        continue;
                    }

                    var output = server.TakeOrder(unparsedOrder);
                    Console.WriteLine("Order Confirmation:");
                    Console.WriteLine(output);

                    orderHistory.Add(unparsedOrder);
                    Console.WriteLine("Your current orders:");
                    foreach (var order in orderHistory)
                    {
                        Console.WriteLine("- " + order);
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Error: " + fe.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
        }

    }
}
