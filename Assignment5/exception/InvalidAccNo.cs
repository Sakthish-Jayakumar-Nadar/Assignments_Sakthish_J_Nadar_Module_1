namespace Assignment5.exception
{
    internal class InvalidAccNo : ApplicationException
    {
        public InvalidAccNo() { }
        public InvalidAccNo(string message) : base(message) { }
    }
}
