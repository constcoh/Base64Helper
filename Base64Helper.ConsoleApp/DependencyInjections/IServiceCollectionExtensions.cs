using Base64Helper.ConsoleApp.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Base64Helper.ConsoleApp.DependencyInjections
{
    public static class IServiceCollectionExtensions
    { 
        public static IServiceCollection AddConsoleDispatcher(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICommandHandler, HelpCommandHandler>();
            serviceCollection.AddScoped<ICommandHandler>((sp) => new EncodeRowCommandHandler("encode"));
            serviceCollection.AddScoped<ICommandHandler>((sp) => new EncodeRowCommandHandler("enc"));
            serviceCollection.AddScoped<ICommandHandler>((sp) => new DecodeRowCommandHandler("decode"));
            serviceCollection.AddScoped<ICommandHandler>((sp) => new DecodeRowCommandHandler("dec"));
            serviceCollection.AddScoped<ICommandHandler>((sp) => new EncodeFileCommandHandler("encode-file"));
            serviceCollection.AddScoped<ICommandHandler>((sp) => new DecodeFileCommandHandler("decode-file"));

            serviceCollection.AddScoped<CommandDispatcher>(sp =>
                new CommandDispatcher(sp, "Base64Helper.ConsoleApp>", "exit"));

            return serviceCollection;
        }
    }
}
