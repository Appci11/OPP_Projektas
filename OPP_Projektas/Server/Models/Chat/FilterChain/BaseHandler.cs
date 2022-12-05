namespace OPP_Projektas.Server.Models.Chat.FilterChain
{
    public abstract class BaseHandler
    {
        private readonly IHandler? _next;

        public BaseHandler(IHandler? nextHandler)
        {
            _next = nextHandler;
        }

        public (bool passed, string value) Handle(string message)
        {
            if (_next != null)
            {
                return _next.Handle(message);
            }

            return (true, message);
        }
    }
}
