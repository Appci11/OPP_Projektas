namespace OPP_Projektas.Server.Models.Chat.Command
{
    public interface ICommand
    {
        void ExecuteAction();
        void UndoAction();
    }
}
