using CuttingEdge.Conditions;

namespace Base64Helper.ConsoleApp.CommandHandlers
{
    public class DecodeFileCommandHandler : ICommandHandler
    {
        private readonly string _commandPrefix;

        public DecodeFileCommandHandler(string commandPrefix)
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

            await DecodeAsync(paramerters[0], paramerters[1]);
        }

        public bool IsSuitableFor(string command)
        {
            return command != null &&
                command.StartsWith(_commandPrefix);
        }

        private Task DecodeAsync(string inputFileName, string outputFileName)
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

            byte[] outputFileBytes;

            try
            {
                var inputFileBytes = File.ReadAllBytes(inputFileName);
                var base64 = System.Text.Encoding.UTF8.GetString(inputFileBytes);
                outputFileBytes = Convert.FromBase64String(base64);
            }
            catch (Exception ex)
            {
                WriteToConsole(new[] {
                    $"  An error occured during decoding from base64.",
                    $"  message: {ex.Message}"
                });

                return Task.CompletedTask;
            }

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
                    $"  The file has been decoded from base64:",
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
