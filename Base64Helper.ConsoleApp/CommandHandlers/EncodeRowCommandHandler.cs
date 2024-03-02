using CuttingEdge.Conditions;

namespace Base64Helper.ConsoleApp.CommandHandlers
{
    public class EncodeRowCommandHandler : ICommandHandler
    {
        private readonly string _commandPrefix;

        public EncodeRowCommandHandler(string commandPrefix)
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

            await EncodeAsync(arg);
        }

        public bool IsSuitableFor(string command)
        {
            return command != null &&
                command.StartsWith(_commandPrefix);
        }

        private Task EncodeAsync(string p)
        {
            Console.WriteLine();
            Console.WriteLine($" \"{p}\" ->");
            Console.WriteLine(Encode(p));
            Console.WriteLine();
            return Task.CompletedTask;
        }

        private string Encode(string arg)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(arg);
            return Convert.ToBase64String(bytes);
        }
    }
}
