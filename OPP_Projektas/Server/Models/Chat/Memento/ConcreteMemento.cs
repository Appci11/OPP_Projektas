using OPP_Projektas.Shared.Models.Chat;

namespace OPP_Projektas.Server.Models.Chat.Memento
{
    class ConcreteMemento : IMemento
    {
        private List<Message> _messages;

        private string _name;

        private DateTime _date;

        public ConcreteMemento(string name, List<Message> messages)
        {
            _name = name;
            _date = DateTime.Now;
            _messages = messages.ToList<Message>();
        }


        public List<Message> GetMessages()
        {
            return _messages;
        }

        public string GetName()
        {
            return _name;
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }
}
