using OPP_Projektas.Shared.Models;
using OPP_Projektas.Shared.Models.BlackJack;
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

    public override void ChooseAction()
    {
        var currentHandValue = Cards.Sum(c => c.ScoreValue);
        if (currentHandValue > 21)
        {
            ChosenAction = BlackJackAction.Stand;
        }
        else if (currentHandValue == 21)
        {
            ChosenAction = BlackJackAction.Stand;
        }
        else
        {
            if (CanDoubleDown && Bet < MaxBet)
            {
                ChosenAction = ChooseDoubleDownAction();
            }
            else
            {
                ChosenAction = ChooseHitOrStandAction();
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