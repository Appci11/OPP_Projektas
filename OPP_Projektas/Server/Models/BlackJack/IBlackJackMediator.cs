using OPP_Projektas.Client.Models.BlackJack;
using OPP_Projektas.Shared.Models.BlackJack;
using OPP_Projektas.Shared.Models.Enums;

namespace OPP_Projektas.Shared.Models;

public interface IBlackJackMediator
{
    void HandleAction(BlackJackAction action, Player player);
    BlackJackDeck Deck { get; set; }
}

public class BlackJackMediator : IBlackJackMediator
{
    private BlackJackPlayer player;
    private BlackJackDealer dealer;

    public BlackJackDeck Deck { get; set; }

    public BlackJackMediator(BlackJackPlayer player, BlackJackDealer dealer)
    {
        this.player = player;
        this.dealer = dealer;
    }

    public void HandleAction(BlackJackAction action, Player actor)
    {
        switch (action)
        {
            case BlackJackAction.Hit:
                if (actor == player)
                {
                    player.RequestCard();
                }
                else
                {
                    dealer.RequestCard();
                }
                break;
            case BlackJackAction.Stand:
                // code to end the player's turn
                break;
            case BlackJackAction.DoubleDown:
                // code to double the player's bet and give them one more card
                break;
            default:
                throw new ArgumentOutOfRangeException("Invalid action");
        }
    }
}

public class Game
{
    private readonly IBlackJackMediator _mediator;

    public Game(IBlackJackMediator mediator)
    {
        _mediator = mediator;
    }

    public void Start()
    {
        _mediator.Deck = new BlackJackDeck();
        BlackJackDeck.Shuffle(_mediator.Deck.Cards);
    }
}
