namespace OPP_Projektas.Server.Models.Chat.FilterChain;

public class LithuanianSwearWordHandler : BaseHandler, IHandler
{
    public LithuanianSwearWordHandler(IHandler? nextHandler) : base(nextHandler)
    {
    }

    public (bool passed, string value) Handle(string message)
    {
        if (message.Contains("Blet", StringComparison.InvariantCultureIgnoreCase))
        {
            return (false, "Please do not swear in chat");
        }
        return base.Handle(message);
    }
}