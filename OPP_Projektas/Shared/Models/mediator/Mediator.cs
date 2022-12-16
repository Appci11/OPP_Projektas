namespace OPP_Projektas.Shared.Models.Mediator;

public class Mediator : IMediator
{
    private List<IColleague> _colleagues;

    public Mediator()
    {
        _colleagues = new List<IColleague>();
    }
    
    public void SendMessage(string message, object sender)
    {
        foreach (var colleague in _colleagues.Where(colleague => colleague != sender))
        {
            colleague.ReceiveMessage(message);
        }
    }

    public void AddColleague(IColleague colleague)
    {
        _colleagues.Add(colleague);
    }
}