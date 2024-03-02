using CuttingEdge.Conditions;

namespace Base64Helper.ConsoleApp.CommandHandlers
{
    public class EncodeFileCommandHandler : ICommandHandler
    {
        private readonly string _commandPrefix;

        public EncodeFileCommandHandler(string commandPrefix)
        {
            Condition.Requires(commandPrefix, nameof(commandPrefix));

            _commandPrefix = commandPrefix + " ";
        }

        public async Task HandleAsync(string command)
        {
            var arg = command.Substring(_commandPrefix.Length);

            var paramerters = command
                .Split(" ")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Skip(1)
                .ToList();

            if (paramerters.Count < 2)
            {
                Console.WriteLine("Wrong command arguments");
                return;
            }

            await EncodeAsync(paramerters[0], paramerters[1]);
        }

        public bool IsSuitableFor(string command)
        {
            return command != null &&
                command.StartsWith(_commandPrefix);
        }

        private Task EncodeAsync(string inputFileName, string outputFileName)
        {
            var doesInputFileExist = File.Exists(inputFileName);
            if(!doesInputFileExist)
            {
                WriteToConsole(new[] {
                    $"  input file does not exist:",
                    $"  {inputFileName}"
                });

                return Task.CompletedTask; 
            }

            var inputFileBytes = File.ReadAllBytes(inputFileName);
            var base64 = Convert.ToBase64String(inputFileBytes);
            var outputFileBytes = System.Text.Encoding.UTF8.GetBytes(base64);

            try
            {
                File.WriteAllBytes(outputFileName, outputFileBytes);
            }
            catch (Exception ex)
            {
                WriteToConsole(new[] {
                    $"  An error occured while writing to the file:",
                    $"  {outputFileName}",
                    $"  message: {ex.Message}"
                });

                return Task.CompletedTask;
            }

            WriteToConsole(new[] {
                    $"  The file has been encoded to base64:",
                    $"  input file: {inputFileName}",
                    $"  output file: {outputFileName}",
                });

            return Task.CompletedTask;
        }

        private void WriteToConsole(string[] args)
        {
            Console.WriteLine();
            foreach (var arg in args) Console.WriteLine(arg);
            Console.WriteLine();
        }
    }
}
