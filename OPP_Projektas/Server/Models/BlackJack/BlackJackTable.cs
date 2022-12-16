using OPP_Projektas.Server.GameHubs;
using OPP_Projektas.Shared.Models.BlackJack;
using OPP_Projektas.Shared.Models.Enums;
using Microsoft.AspNetCore.SignalR;

namespace OPP_Projektas.Server.Models.BlackJack;

public class BlackJackTable
{
    private Guid _id;
    public int MinBet { get; set; }
    public int MaxBet { get; set; }
    public double BlackJackRatio { get; set; } = 1.5;
    public List<BlackJackPlayer> Players { get; set; }
    public BlackJackGameState BlackJackGameState { get; set; }
    public BlackJackDeck Deck { get; set; }
    public List<BlackJackCard> DealerCards { get; set; }

    private readonly IHubContext<BlackJackHub> _hub;
    public IHubCallerClients Clients { get; set; }

    public BlackJackTable(IHubContext<BlackJackHub> hub)
    {
        _hub = hub;
        BuildBlackJackSet();
    }

    public BlackJackTable(Guid tableId)
    {
        _id = tableId;
        Players = new List<BlackJackPlayer>();
        DealerCards = new List<BlackJackCard>();
        MinBet = 1;
        MaxBet = 100;

        BuildBlackJackSet();
    }
    
    private void BuildBlackJackSet()
    {
        var builder = new BlackJackSetBuilder();
        for (var i = 0; i < 8; i++)
        {
            builder.AddAces();
            builder.AddKings();
            builder.AddQueens();
            builder.AddJacks();
            builder.AddNumbers();
        }

        Deck = builder.GetBlackJackDeck();
        BlackJackDeck.Shuffle(Deck.Cards);
    }

    public async Task Play()
    {
        await BettingPhase();
        await InitialDealPhase();
    }

    public async Task BettingPhase()
    {
        BlackJackGameState = BlackJackGameState.Betting;
        if (IsGameStopped())
        {
            return;
        }

        foreach (var player in Players)
        {
            player.Balance -= player.Bet;
        }

        // await _hub.Clients.All.SendAsync("BettingPhase");
        // await Task.Delay(30000);
        // await _hub.Clients.All.SendAsync("BettingPhaseDone");
        await Clients.All.SendAsync("BettingPhaseDone", Players[0]);
    }

    public async Task InitialDealPhase()
    {
        BlackJackGameState = BlackJackGameState.DealerPhase;
        
        // await _hub.Clients.All.SendAsync("InitialDealPhase");
        await Clients.All.SendAsync("InitialDealPhase");
        foreach (var player in Players)
        {
            var card = Deck.Draw();
            player.Cards.Add(card);
            // await _hub.Clients.All.SendAsync("CardDealt", player.Id.ToString(), card);
            await Task.Delay(1000);
            await Clients.All.SendAsync("CardDealt", player.Id.ToString(), card);
        }

        var dealerCard = Deck.Draw();
        DealerCards.Add(dealerCard);
        // await _hub.Clients.All.SendAsync("CardDealt", "Dealer", Deck.Draw());
        await Task.Delay(1000);
        await Clients.All.SendAsync("CardDealt", "Dealer", Deck.Draw());

        foreach (var player in Players)
        {
            var card = Deck.Draw();
            player.Cards.Add(card);
            // await _hub.Clients.All.SendAsync("CardDealt", player.Id.ToString(), card);
            await Task.Delay(1000);
            await Clients.All.SendAsync("CardDealt", player.Id.ToString(), card);
        }

        dealerCard = Deck.Draw();
        DealerCards.Add(dealerCard);
        await Task.Delay(1000);
        // await _hub.Clients.All.SendAsync("CardDealt", "Dealer", Deck.Draw());
        // await _hub.Clients.All.SendAsync("InitialDealPhaseOver");
        await Clients.All.SendAsync("CardDealt", "Dealer", Deck.Draw());
        await Clients.All.SendAsync("InitialDealPhaseOver");
    }

    private bool IsGameStopped()
    {
        return BlackJackGameState == BlackJackGameState.Stopped;
    }
}