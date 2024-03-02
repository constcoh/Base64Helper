using Base64Helper.ConsoleApp.CommandHandlers;
using CuttingEdge.Conditions;

namespace Base64Helper.ConsoleApp
{
    public class CommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _welcomeString;
        private readonly string _exitCommand;

        public CommandDispatcher(
            IServiceProvider serviceProvider,
            string welcomeString,
            string exitCommand)
        {
            Condition.Requires(welcomeString, nameof(welcomeString)).IsNotNull();
            Condition.Requires(exitCommand, nameof(exitCommand)).IsNotNull();

            _serviceProvider = serviceProvider;
            _welcomeString = welcomeString;
            _exitCommand = exitCommand;
        }

        public async Task RunAsync()
        {
            // Write welcome:
            await GetCommandHandler("help").HandleAsync("help");

            var currentCommand = string.Empty;
            while (currentCommand != _exitCommand)
            {
                Console.Write(_welcomeString);
                currentCommand = Console.ReadLine();

                if (currentCommand == _exitCommand)
                {
                    return;
                }

                var handler = GetCommandHandler(currentCommand);

                // run "help" if command is not parsed
                if (handler == null)
                {
                    Console.WriteLine("Unknown command: " + currentCommand);
                    Console.WriteLine("Please input \"help\" for more instructions.");
                    continue;
                }

                try
                {
                    await handler.HandleAsync(currentCommand);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private ICommandHandler GetCommandHandler(string command)
        {
            var handlers = _serviceProvider.GetService(typeof(IEnumerable<ICommandHandler>)) as IEnumerable<ICommandHandler>;

            return handlers
                .FirstOrDefault(x => x.IsSuitableFor(command));
        }
    }
}
