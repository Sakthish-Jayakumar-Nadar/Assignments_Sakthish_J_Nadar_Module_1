namespace WebApplication1.Custom_Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
    }
}
