using CuttingEdge.Conditions;

namespace Base64Helper.ConsoleApp.CommandHandlers
{
    public class DecodeRowCommandHandler : ICommandHandler
    {
        private readonly string _commandPrefix;

        public DecodeRowCommandHandler(string commandPrefix)
        {
            Condition.Requires(commandPrefix, nameof(commandPrefix));

            _commandPrefix = commandPrefix + " ";
        }

        public async Task HandleAsync(string command)
        {
            var arg = command.Substring(_commandPrefix.Length);

            if (arg.Length == 0)
            {
                Console.WriteLine("Wrong command arguments");
                return;
            }

            await DecodeAsync(arg);
        }

        public bool IsSuitableFor(string command)
        {
            return command != null &&
                command.StartsWith(_commandPrefix);
        }

        private Task DecodeAsync(string p)
        {
            Console.WriteLine();
            Console.WriteLine($" \"{p}\" ->");
            Console.WriteLine(Decode(p));
            Console.WriteLine();
            return Task.CompletedTask;
        }

        private string Decode(string arg)
        {
            while (arg.Length % 4 != 0) arg += "=";

            var bytes = Convert.FromBase64String(arg);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}
