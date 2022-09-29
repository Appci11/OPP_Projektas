using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.Slots;

namespace OPP_Projektas.Server.GameHubs;

public class SlotsHub : Hub
{
    public async Task Play(string playerName, int betSize)
    {
        var win = Slots.Play(betSize);
        await Clients.Caller.SendAsync("SlotResult", win);
    }

    public async Task BroadcastWin(string playerName, int winSize)
    {
        Console.WriteLine($"{playerName} - {winSize}");
        await Clients.All.SendAsync("WinBroadcasted", $"{playerName} just won ${winSize}!!!!");
    }

}