using OPP_Projektas.Shared.Models.Chat;

namespace OPP_Projektas.Server.Models.Chat.Command
{
    public class Receiver
    {
        public List<Message> Messages { get; set; }

        public Receiver(List<Message> messages)
        {
            this.Messages = messages;
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }

        public void RemoveLastMessage()
        {
            Messages.RemoveAt(Messages.Count - 1);
        }
    }
}
