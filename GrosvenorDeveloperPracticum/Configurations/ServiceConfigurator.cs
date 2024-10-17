using GrosvenorDeveloperPracticum.Application;
using GrosvenorDeveloperPracticum.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GrosvenorDeveloperPracticum.Configurations
{
    public static class ServiceConfigurator
    {
        public static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddScoped<IDishManager, DishManager>()
                .AddScoped<IServer, Server>()
                .BuildServiceProvider();
        }
    }
}
