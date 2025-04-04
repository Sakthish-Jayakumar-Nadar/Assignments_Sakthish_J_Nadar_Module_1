namespace LMS.Application.Exception
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message) { }
    }
}
