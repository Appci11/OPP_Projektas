using OPP_Projektas.Server.GameHubs;
using OPP_Projektas.Shared.Models.BlackJack;
using OPP_Projektas.Shared.Models.Enums;
using System;
using Microsoft.AspNetCore.SignalR;
using System.Numerics;

namespace OPP_Projektas.Server.Models.BlackJack;

public class BlackJackTable
{
    public int MinBet { get; set; }
    public int MaxBet { get; set; }
    public double BlackJackRatio { get; set; } = 1.5;
    public List<BlackJackPlayer> Players { get; set; }
    public BlackJackGameState BlackJackGameState { get; set; }
    public BlackJackDeck Deck { get; set; }
    public List<BlackJackCard> DealerCards { get; set; }

    private readonly IHubContext<BlackJackHub> _hub;

    public BlackJackTable(IHubContext<BlackJackHub> hub)
    {
        _hub = hub;
        Deck = new BlackJackDeck(8);
    }

    public async void Play()
    {
        await BettingPhase();
        await InitialDealPhase();
    }

    public async Task BettingPhase()
    {
        if (IsGameStopped())
        {
            return;
        }

        await _hub.Clients.All.SendAsync("BettingPhase");
        await Task.Delay(30000);
        await _hub.Clients.All.SendAsync("BettingPhaseDone");
    }

    public async Task InitialDealPhase()
    {
        await _hub.Clients.All.SendAsync("InitialDealPhase");
        foreach (var player in Players)
        {
            var card = Deck.Draw();
            player.Cards.Add(card);
            await _hub.Clients.All.SendAsync("CardDealt", player.Id.ToString(), card);
        }

        var dealerCard = Deck.Draw();
        DealerCards.Add(dealerCard);
        await _hub.Clients.All.SendAsync("CardDealt", "Dealer", Deck.Draw());

        foreach (var player in Players)
        {
            var card = Deck.Draw();
            player.Cards.Add(card);
            await _hub.Clients.All.SendAsync("CardDealt", player.Id.ToString(), card);
        }

        dealerCard = Deck.Draw();
        DealerCards.Add(dealerCard);
        await _hub.Clients.All.SendAsync("CardDealt", "Dealer", Deck.Draw());
        await _hub.Clients.All.SendAsync("InitialDealPhaseOver");
    }

    private bool IsGameStopped()
    {
        return BlackJackGameState == BlackJackGameState.Stopped;
    }

}