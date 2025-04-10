namespace TeachLink_BackEnd.Infrastructure.GlobalHendelrs
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message)
            : base(message) { }
    }
}
