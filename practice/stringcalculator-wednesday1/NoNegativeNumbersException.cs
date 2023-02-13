namespace StringCalculator
{
    public class NoNegativeNumbersException : ArgumentOutOfRangeException
    {
        public NoNegativeNumbersException(string message) : base(message) { }
    }
}
