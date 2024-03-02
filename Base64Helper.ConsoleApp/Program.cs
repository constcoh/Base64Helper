using Base64Helper.ConsoleApp.DependencyInjections;
using Microsoft.Extensions.DependencyInjection;

namespace Base64Helper.ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = new DependencyInjection().CreateServiceProvider();

            var dispatcher = serviceProvider.GetService<CommandDispatcher>();
            await dispatcher.RunAsync();
        }
    }
}