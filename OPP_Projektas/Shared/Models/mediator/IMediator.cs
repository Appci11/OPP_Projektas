namespace OPP_Projektas.Shared.Models.Mediator;

public interface IMediator
{
    void SendMessage(string message, object sender);
    void AddColleague(IColleague colleague);
}