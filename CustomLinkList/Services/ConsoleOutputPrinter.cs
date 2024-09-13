using CustomLinkList.Contract;

namespace CustomLinkList.Services
{
    public class ConsoleOutputPrinter : IOutputPrinter
    {
        public void Print(string? message)
        {
            Console.WriteLine(message);
        }
    }
}
