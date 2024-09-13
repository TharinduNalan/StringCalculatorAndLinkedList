namespace StringCalculator.Exceptions
{
    public class InvalidDelimiterException : Exception
    {
        public InvalidDelimiterException(char delimiter) : base($"{delimiter} is not a valid delimiter")
        {

        }

        public InvalidDelimiterException(string message) : base(message)
        {

        }
    }
}
