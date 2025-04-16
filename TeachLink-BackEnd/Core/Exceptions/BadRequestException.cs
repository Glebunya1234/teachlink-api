namespace TeachLink_BackEnd.Infrastructure.GlobalHendelrs
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message) { }
    }
}
