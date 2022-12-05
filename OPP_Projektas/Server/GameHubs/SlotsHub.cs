using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.Slots;
using OPP_Projektas.Server.Models.Slots.Proxies;
using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;
using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Server.GameHubs;

public class SlotsHub : Hub
{
    public async Task Play(string playerName, int betSize, bool isPictureSymbols, SlotType slotType)
    {
        Console.WriteLine("icri1");
        ISymbolTier garbage = new TierFirst();

        var slots = new SlotsManager();
        //var slots = new BonusSlotsManager();
        SlotsResult win = slots.Play(betSize, isPictureSymbols, slotType);
        Console.WriteLine("win: "+win.Payout);

        Tuple<int, List<SymbolTier>> result;
        List<SymbolTier> tiers = new List<SymbolTier>();
        foreach(ISymbolTier tier in win.SlotSymbols)
        {
            switch (tier)
            {
                case TierFirst:
                    tiers.Add(SymbolTier.First);
                    break;
                case TierSecond:
                    tiers.Add(SymbolTier.Second);
                    break;
                case TierThird:
                    tiers.Add(SymbolTier.Third);
                    break;
                case TierFourth:
                    tiers.Add(SymbolTier.Fourth);
                    break;
                case TierFifth:
                    tiers.Add(SymbolTier.Fifth);
                    break;
            }
        }

        result = new Tuple<int, List<SymbolTier>>( win.Payout, tiers );

        await Clients.Caller.SendAsync("Test");
        await Clients.Caller.SendAsync("Something",  result);
        //await Clients.Caller.SendAsync("Something", garbage);
        Console.WriteLine("Sent message");
    }

    public async Task BroadcastWin(string playerName, int winSize)
    {
        Console.WriteLine("icri3");

        Console.WriteLine($"{playerName} - {winSize}");
        await Clients.All.SendAsync("WinBroadcasted", $"{playerName} just won ${winSize}!!!!");
    }

}