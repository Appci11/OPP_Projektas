using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.BlackJack;
using OPP_Projektas.Shared.Models.BlackJack;

namespace OPP_Projektas.Server.Services;

public class BlackJackTableServices
{
    private BlackJackTable _table;
    public bool TimerStopped = true;
    public IHubCallerClients Clients;
    private int playersBet = 0;
    private int totalTime = 60;

    public async Task AddPlayer(BlackJackPlayer player, Guid tableGuid)
    {
        _table = new BlackJackTable(tableGuid);
        _table.Players.Add(player);
        if (_table.Players.Count == 1)
        {
            await RunTimer();
        }
    }

    public async Task PlayerBet(Guid playerId, int betSize)
    {
        var player = _table.Players.FirstOrDefault(jackPlayer => jackPlayer.Id.Equals(playerId));
        if (player is null)
        {
            return;
        }

        player.Bet = betSize;
        
        if (TimerStopped)
        {
            throw new InvalidOperationException("Bets are closed!");
        }

        if (playersBet == _table.Players.Count)
        {
            await Clients.All.SendAsync("BettingPhaseDone");
            return;
        }

        await Clients.All.SendAsync("UpdatePlayer", player);
    }
    
    private async Task RunTimer()
    {
        TimerStopped = false;
        var timer = new Timer(OnTimerElapsed, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        await Clients.All.SendAsync("BettingPhaseStarted");
        while (!TimerStopped)
        {
            if (TimerStopped)
            {
                await timer.DisposeAsync();
            }
        }
    }
    
    private async void OnTimerElapsed(object? state)
    {
        totalTime--;
        
        if (totalTime <= 0)
        {
            TimerStopped = true;
            await Clients.All.SendAsync("BettingPhaseDone");
        }
    }

    public async Task Play()
    {
        throw new NotImplementedException();
    }
}