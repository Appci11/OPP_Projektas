using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.BlackJack;
using OPP_Projektas.Shared.Models.BlackJack;
using OPP_Projektas.Shared.Models.Enums;

namespace OPP_Projektas.Server.Services;

public class BlackJackTableServices
{
    private BlackJackTable _table;
    private bool _timerStopped = true;
    public IHubCallerClients Clients;
    private int _playersBet = 0;
    private int _totalTime = 60;

    public async Task AddPlayer(BlackJackPlayer player)
    {
        _table.Players.Add(player);
        if (_table.Players.Count == 1)
        {
            await RunTimer();
        }
    }

    public async Task PlayerBet(BlackJackPlayer player, int betSize)
    {
        if (_timerStopped)
        {
            throw new InvalidOperationException("Bets are closed!");
        }
        
        player.Bet = betSize;
        _playersBet++;

        if (_playersBet == _table.Players.Count)
        {
            await Clients.All.SendAsync("BettingPhaseDone");
            return;
        }

        await Clients.All.SendAsync("UpdatePlayer", player);
    }
    
    public async Task Play()
    {
        await _table.Play();
    }

    public BlackJackTable CreateTable(BlackJackDealer dealer)
    {
        _table = new BlackJackTable(dealer)
        {
            Clients = Clients,
            BlackJackGameState = BlackJackGameState.Stopped
        };

        return _table;
    }

    public BlackJackCard DrawCard()
    {
        return _table.Deck.Draw();
    }
    
    private async Task RunTimer()
    {
        _timerStopped = false;
        var timer = new Timer(OnTimerElapsed, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        await Clients.All.SendAsync("BettingPhaseStarted");
        while (!_timerStopped)
        {
            if (_timerStopped)
            {
                await timer.DisposeAsync();
            }
        }
    }
    
    private async void OnTimerElapsed(object? state)
    {
        _totalTime--;
        Console.WriteLine($"Time left: {_totalTime}");
        if (_totalTime > 0) 
            return;
        _timerStopped = true;
        await Clients.All.SendAsync("BettingPhaseDone");
    }
}