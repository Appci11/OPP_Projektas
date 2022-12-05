namespace OPP_Projektas.Server.Models.Chat.FilterChain;

public class AskHowHandler : BaseHandler, IHandler
{
    public AskHowHandler(IHandler? nextHandler) : base(nextHandler)
    {
    }

    public (bool passed, string value) Handle(string message)
    {
        if (message.Contains("How", StringComparison.InvariantCultureIgnoreCase) && message.Contains("?"))
        {
            return (false, "If you have questions about how the system works, contact the administrators. Chat users might try to scam you");
        }
        return base.Handle(message);
    }
}