using Microsoft.AspNetCore.SignalR.Client;
using OPP_Projektas.Shared.Models.Enums;
using OPP_Projektas.Shared.Models.Mediator;

namespace OPP_Projektas.Shared.Models.BlackJack;

public class BlackJackDealer : Player, IColleague
{
    private IMediator _mediator;
    
    public override void ChooseAction()
    {
        var currentHandValue = Cards.Sum(c => c.ScoreValue);
        switch (currentHandValue)
        {
            case > 21:
            case 21:
                ChosenAction = BlackJackAction.Stand;
                break;
            default:
            {
                ChosenAction = BlackJackAction.Hit;
                break;
            }
        }
    }

    public BlackJackDealer(HubConnection hubConnection, IMediator mediator) : base(hubConnection)
    {
        this._mediator = mediator;
        _mediator.AddColleague(this);
    }

    public void ReceiveMessage(string message)
    {
        if (message.Equals("Cheat"))
        {
            HubConnection.SendAsync("DealerCheat", Id);
        }
    }
}