namespace TeachLink_BackEnd.Infrastructure.GlobalHendelrs
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message) { }
    }
}
