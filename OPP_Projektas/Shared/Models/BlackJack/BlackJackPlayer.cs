using Microsoft.AspNetCore.SignalR.Client;
using OPP_Projektas.Shared.Models.Enums;
using OPP_Projektas.Shared.Models.Mediator;

namespace OPP_Projektas.Shared.Models.BlackJack;

public class BlackJackPlayer : Player, IColleague
{
    private IMediator _mediator;
    public int Balance { get; set; }
 
    public int MaxBet { get; set; }

    public bool CanDoubleDown
    {
        get
        {
            if (Cards.Count < 2)
                return false;
            var firstTwoValues = Cards[0].ScoreValue + Cards[1].ScoreValue;
            return firstTwoValues is >= 9 and <= 11;
        }
    }

    public BlackJackAction ActionChoise {get;set;}
    
    public BlackJackPlayer(HubConnection hubConnection, int maxBet, IMediator mediator) : base(hubConnection)
    {
        MaxBet = maxBet;
        _mediator = mediator;
        _mediator.AddColleague(this);
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
        return ActionChoise;
    }

    public BlackJackAction ChooseDoubleDownAction()
    {
        return ActionChoise;
    }

    public void ReceiveMessage(string message)
    {
        ActionChoise = message switch
        {
            "Hit" => BlackJackAction.Hit,
            "Stand" => BlackJackAction.Stand,
            "DoubleDown" => BlackJackAction.DoubleDown,
            _ => BlackJackAction.None
        };
    }
}