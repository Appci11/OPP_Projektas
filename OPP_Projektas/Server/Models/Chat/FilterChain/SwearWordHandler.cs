namespace OPP_Projektas.Server.Models.Chat.FilterChain;

public class SwearWordHandler : BaseHandler, IHandler
{
    public SwearWordHandler(IHandler? nextHandler): base(nextHandler)
    {
    }

    public (bool passed, string value) Handle(string message)
    {
        if (message.Contains("Fuck", StringComparison.InvariantCultureIgnoreCase))
        {
            return (false, "Please do not swear in chat");
        }
        return base.Handle(message);
    }
}