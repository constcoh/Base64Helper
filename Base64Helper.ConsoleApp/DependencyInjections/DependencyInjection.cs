using Microsoft.Extensions.DependencyInjection;

namespace Base64Helper.ConsoleApp.DependencyInjections
{
    public class DependencyInjection
    {
        public DependencyInjection()
        {
        }

        public IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .AddConsoleDispatcher()
                .BuildServiceProvider();
        }
    }
}
