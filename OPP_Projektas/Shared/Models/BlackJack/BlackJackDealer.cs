using Microsoft.AspNetCore.SignalR.Client;
using OPP_Projektas.Shared.Models.Enums;

namespace OPP_Projektas.Shared.Models.BlackJack;

public class BlackJackDealer : Player
{
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

    public BlackJackDealer(HubConnection hubConnection) : base(hubConnection)
    {
    }
}