using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.Slots;
using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;

namespace OPP_Projektas.Server.GameHubs;

public class SlotsHub : Hub
{
    public async Task Play(string playerName, int betSize, bool isPictureSymbols)
    {
        var slots = Slots.GetInstance();
        var win = slots.Play(betSize, isPictureSymbols);
        await Clients.Caller.SendAsync("Test");
        await Clients.Caller.SendAsync("Something",  win);
        Console.WriteLine("Sent message");
    }

    public async Task BroadcastWin(string playerName, int winSize)
    {
        Console.WriteLine($"{playerName} - {winSize}");
        await Clients.All.SendAsync("WinBroadcasted", $"{playerName} just won ${winSize}!!!!");
    }

}