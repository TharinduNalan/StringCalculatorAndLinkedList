using CustomLinkList.Contract;

namespace CustomLinkList.UnitTests.Fake
{
    public class FakeOutputPrinter : IOutputPrinter
    {
        public List<string> Output { get; } = new List<string>();

        public void Print(string? message)
        {
            Output.Add(message!);
        }
    }
}
