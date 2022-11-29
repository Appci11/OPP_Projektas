using OPP_Projektas.Shared.Models.Chat;

namespace OPP_Projektas.Server.Models.Chat.Memento
{
    public interface IMemento
    {
        string GetName();

        DateTime GetDate();

        List<Message> GetMessages();
    }
}
