using OPP_Projektas.Server.GameHubs;
using OPP_Projektas.Shared.Models.BlackJack;
using OPP_Projektas.Shared.Models.Enums;
using Microsoft.AspNetCore.SignalR;

namespace OPP_Projektas.Server.Models.BlackJack;

public class BlackJackTable
{
    public int MinBet { get; set; }
    public int MaxBet { get; set; }
    public double BlackJackRatio { get; set; } = 1.5;
    public List<BlackJackPlayer> Players { get; set; }
    public BlackJackGameState BlackJackGameState { get; set; }
    public BlackJackDeck Deck { get; set; }
    public BlackJackDealer Dealer { get; set; }
    public IHubCallerClients Clients { get; set; }
    
    public BlackJackTable(BlackJackDealer dealer)
    {
        Players = new List<BlackJackPlayer>();
        Dealer = dealer;
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
        await InitialDealPhase();
    }

    public async Task InitialDealPhase()
    {
        BlackJackGameState = BlackJackGameState.DealerPhase;
        
        await Clients.All.SendAsync("InitialDealPhase");
        foreach (var player in Players)
        {
            var card = Deck.Draw();
            player.Cards.Add(card);
            await Task.Delay(1000);
            await Clients.All.SendAsync("CardDealt", player.Id, card);
        }

        var dealerCard = Deck.Draw();
        Dealer.Cards.Add(dealerCard);
        await Task.Delay(1000);
        await Clients.All.SendAsync("CardDealt", Dealer.Id, Deck.Draw());

        foreach (var player in Players)
        {
            var card = Deck.Draw();
            player.Cards.Add(card);
            await Task.Delay(1000);
            await Clients.All.SendAsync("CardDealt", player.Id, card);
        }

        dealerCard = Deck.Draw();
        Dealer.Cards.Add(dealerCard);
        await Task.Delay(1000);
        await Clients.All.SendAsync("CardDealt", Dealer.Id, Deck.Draw());
        await Clients.All.SendAsync("InitialDealPhaseOver");
    }

    private bool IsGameStopped()
    {
        return BlackJackGameState == BlackJackGameState.Stopped;
    }
}