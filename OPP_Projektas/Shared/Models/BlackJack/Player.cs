using Microsoft.AspNetCore.SignalR.Client;
using OPP_Projektas.Shared.Models.Enums;

namespace OPP_Projektas.Shared.Models.BlackJack;

/// <summary>
/// Template
/// </summary>
public abstract class Player
{
    protected Player(HubConnection hubConnection)
    {
        ChosenAction = BlackJackAction.None;
        HubConnection = hubConnection;
        Id = Guid.NewGuid();
        Bet = 0;
    }

    public HubConnection HubConnection { get; set; }
    public Guid Id { get; set; }
    public int Bet { get; set; }
    
    public List<BlackJackCard> Cards { get; set; } = new();
    
    protected BlackJackAction ChosenAction;

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
        if (GetType() == typeof(BlackJackPlayer))
        {
            Console.WriteLine("Player stands");
        }
        else
            throw new InvalidOperationException("Dealer cannot stand");
    }

    public void RequestCard()
    {
        HubConnection.SendAsync("DrawCard", Id);
    }

    public abstract void ChooseAction();
    
}