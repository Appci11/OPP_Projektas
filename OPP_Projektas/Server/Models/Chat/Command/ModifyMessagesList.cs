namespace OPP_Projektas.Server.Models.Chat.Command
{
    public class ModifyMessagesList
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;
        private int actionNumber = 0;

        public ModifyMessagesList()
        {
            _commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => _command = command;

        public void Invoke()
        {
            _commands.Add(_command);
            _command.ExecuteAction();
            int c = actionNumber - _commands.Count;
            if (c > 0)
            {
                _commands.RemoveRange(actionNumber - 1, c);
            }
            actionNumber = _commands.Count;
        }

        public void UndoActions()
        {
            foreach (var command in Enumerable.Reverse(_commands))
            {
                command.UndoAction();
            }
        }

        public void UndoAction()
        {
            int n = actionNumber - 1;
            if (n >= 0)
            {
                _commands[actionNumber - 1].UndoAction();
                actionNumber--;
            }

        }

        public void RedoAction()
        {
            if (_commands.Count - actionNumber > 0)
            {
                _commands[actionNumber].ExecuteAction();
                actionNumber++;
            }
        }
    }
}
