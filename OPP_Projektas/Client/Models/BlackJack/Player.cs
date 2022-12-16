using Microsoft.AspNetCore.SignalR.Client;
using OPP_Projektas.Shared.Models.BlackJack;
using OPP_Projektas.Shared.Models.Enums;

namespace OPP_Projektas.Client.Models.BlackJack;

/// <summary>
/// Template
/// </summary>
public abstract class Player
{
    public HubConnection HubConnection { get; set; }
    public Guid Id { get; set; }
    public int Bet { get; set; }
    
    public List<BlackJackCard> Cards { get; set; } = new();
    
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
        HubConnection.SendAsync("PlayerDoubleDown", Id, Bet);
    }

    public void Stand()
    {
        HubConnection.SendAsync("PlayerStand", Id);
    }

    public void RequestCard()
    {
        HubConnection.SendAsync("PlayerRequestCard", Id);
    }

    public abstract void ChooseAction();
    
}