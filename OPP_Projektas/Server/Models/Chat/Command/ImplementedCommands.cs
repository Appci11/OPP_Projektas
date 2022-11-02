using OPP_Projektas.Shared.Models.Chat;

namespace OPP_Projektas.Server.Models.Chat.Command
{
    public class ImplementedCommands : ICommand
    {
        private readonly Receiver _receiver;
        private readonly CommandsEnum _actionCommands;
        private readonly Message _message;

        public ImplementedCommands(Receiver rec, CommandsEnum actionCommands, Message message)
        {
            _receiver = rec;
            _actionCommands = actionCommands;
            _message = message;
        }
        public void ExecuteAction()
        {
            if (_actionCommands == CommandsEnum.Add)
            {
                _receiver.AddMessage(_message);
            }
            else
            {
                _receiver.RemoveLastMessage();
            }
        }

        public void UndoAction()
        {
            if (_actionCommands == CommandsEnum.Add)
            {
                _receiver.RemoveLastMessage();
            }
            else
            {
                _receiver.AddMessage(_message);
            }
        }
    }
}
