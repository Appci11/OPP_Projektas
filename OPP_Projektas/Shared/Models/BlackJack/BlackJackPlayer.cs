using Microsoft.AspNetCore.SignalR.Client;
using OPP_Projektas.Shared.Models.Enums;

namespace OPP_Projektas.Client.Models.BlackJack;

public class BlackJackPlayer : Player
{
    public int Balance { get; set; }
 
    public int MaxBet { get; set; }

    public bool CanDoubleDown
    {
        get
        {
            var firstTwoValues = Cards[0].ScoreValue + Cards[1].ScoreValue;
            return firstTwoValues is >= 9 and >= 11;
        }
    }
    
    public BlackJackPlayer(HubConnection hubConnection, int maxBet) : base(hubConnection)
    {
        MaxBet = maxBet;
    }

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
                ChosenAction = CanDoubleDown && Bet < MaxBet ? ChooseDoubleDownAction() : ChooseHitOrStandAction();
                break;
            }
        }
    }

    public BlackJackAction ChooseHitOrStandAction()
    {
        throw new NotImplementedException();
    }

    public BlackJackAction ChooseDoubleDownAction()
    {
        throw new NotImplementedException();
    }
}