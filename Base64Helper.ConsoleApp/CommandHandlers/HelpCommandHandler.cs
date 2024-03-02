namespace Base64Helper.ConsoleApp.CommandHandlers
{
    public class HelpCommandHandler : ICommandHandler
    {
        public const string Command = "help";

        private const string _helpText =
            "\r\n Whelcome to the program to encode and decode base64" +
            "\r\n" +
            "\r\n Next commands are supported:" +
            "\r\n " +
            "\r\n encode, enc - encode row to base64, example:" +
            "\r\n  >encode abs qes" +
            "\r\n  \"abs qes\" ->" +
            "\r\n  YWJzIHFlcw==" +
            "\r\n " +
            "\r\n decode, dec - decode row from base64, example:" +
            "\r\n  >dec YWJzIHFlcw==" +
            "\r\n  \"YWJzIHFlcw==\" ->" +
            "\r\n  abs qes" +
            "\r\n " +

            "\r\n encode-file [inputfile] [outputfile] - encode file to base64, examples:" +
            "\r\n  >encode-file C:\\test\\input.zip C:\\test\\output.zip" +
            "\r\n  >encode-file C:\\\\test\\\\input.zip C:\\\\test\\\\output.zip" +
            "\r\n " +
            "\r\n decode-file [inputfile] [outputfile] - decode file from base64, examples:" +
            "\r\n  >decode-file C:\\test\\input.zip C:\\test\\output.zip" +
            "\r\n  >decode-file C:\\\\test\\\\input.zip C:\\\\test\\\\output.zip" +
            "\r\n " +
            "\r\n exit - it closes the program" +
            "\r\n";

        public HelpCommandHandler()
        {
        }

        public async Task HandleAsync(string command)
        {
            await Task.CompletedTask;
            if (!IsSuitableFor(command)) return;
            Console.WriteLine(_helpText);
        }

        public bool IsSuitableFor(string command)
        {
            return command == Command;
        }
    }
}
