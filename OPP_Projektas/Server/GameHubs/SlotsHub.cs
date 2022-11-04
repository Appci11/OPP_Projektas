using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.Slots;
using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;

namespace OPP_Projektas.Server.GameHubs;

public class SlotsHub : Hub
{
    public async Task Play(string playerName, int betSize, bool isPictureSymbols, SlotType slotType)
    {
        Console.WriteLine("icri1");

        var slots = Slots.GetInstance();
        SlotsResult win = slots.Play(betSize, isPictureSymbols, slotType);
        Console.WriteLine("win: "+win.Payout);
        await Clients.Caller.SendAsync("Test");
        await Clients.Caller.SendAsync("Something",  win);
        Console.WriteLine("Sent message");
    }

    public async Task BroadcastWin(string playerName, int winSize)
    {
        Console.WriteLine("icri3");

        Console.WriteLine($"{playerName} - {winSize}");
        await Clients.All.SendAsync("WinBroadcasted", $"{playerName} just won ${winSize}!!!!");
    }

}