namespace OPP_Projektas.Server.Models.Chat.FilterChain;

public class PasswordAskerHandler : BaseHandler, IHandler
{
    public PasswordAskerHandler(IHandler? nextHandler) : base(nextHandler)
    {
    }

    public (bool passed, string value) Handle(string message)
    {
        if (message.Contains("password", StringComparison.InvariantCultureIgnoreCase) && message.Contains("?"))
        {
            return (false, "Do not ask other users to provide their passwords in chat");
        }
        return base.Handle(message);
    }
}