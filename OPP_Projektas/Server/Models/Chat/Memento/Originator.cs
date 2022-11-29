using OPP_Projektas.Shared.Models.Chat;

namespace OPP_Projektas.Server.Models.Chat.Memento
{
    class Originator
    {
        private string _name;
        public List<Message> _messages { get; set; } = new List<Message>();

        public Originator(List<Message> messages)
        {
            _messages = messages.ToList<Message>();
        }

        public IMemento Save(string saveName)
        {
            return new ConcreteMemento(saveName, _messages);
        }

        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            this._name = memento.GetName();
            _messages = memento.GetMessages().ToList<Message>();
        }
    }
}
