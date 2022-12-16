using Microsoft.AspNetCore.SignalR.Client;
using OPP_Projektas.Shared.Models.Enums;

namespace OPP_Projektas.Shared.Models;

/// <summary>
/// Template
/// </summary>
public abstract class Player
{
    protected BlackJackAction ChosenAction = BlackJackAction.None;

    public void TakeTurn()
    {
        ChooseAction();

        switch (ChosenAction)
        {
            case BlackJackAction.Hit:
                RequestCard();
                break;
            case BlackJackAction.Stand:
                Stand();
                break;
            case BlackJackAction.DoubleDown:
                DoubleDown();
                break;
            case BlackJackAction.None:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void DoubleDown()
    {
        throw new NotImplementedException();
    }

    public void Stand()
    {
        throw new NotImplementedException();
    }

    public void RequestCard()
    {
        throw new NotImplementedException();
    }

    public abstract void ChooseAction();
    
}