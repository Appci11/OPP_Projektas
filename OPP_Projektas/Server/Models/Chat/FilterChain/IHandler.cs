namespace OPP_Projektas.Server.Models.Chat.FilterChain;

public interface IHandler
{
    public (bool passed, string value) Handle(string message);
}