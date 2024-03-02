namespace Base64Helper.ConsoleApp
{
    public interface ICommandHandler
    {
        bool IsSuitableFor(string command);

        Task HandleAsync(string command);
    }
}
