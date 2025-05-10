namespace TeachLink_BackEnd.Infrastructure.GlobalHendelrs
{
    public class BadRequestException : ArgumentException
    {
        public BadRequestException(string message)
            : base(message) { }
    }
}
