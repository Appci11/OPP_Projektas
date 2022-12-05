using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Formatters;
using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;

namespace OPP_Projektas.Server.Models.Slots;

public class Slots : ISlots
{
    private static Slots? _instance = null;

    public static Slots GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Slots();
        }

        return _instance;
    }


    public SlotsResult Play(int betAmount, bool isPictureSymbols, SlotType type)
    {
        int payout = 0;
        List<ISlotSymbol> slotSymbols = new List<ISlotSymbol>();
        var context = new SlotContext();
        switch (type)
        {
            case SlotType.Simple:
                context.SetStrategy(new SimpleSlotStrategy());
                break;
            case SlotType.Coinflip:
                context.SetStrategy(new CoinflipSlotStrategy());
                break;
            case SlotType.Jackpot:
                context.SetStrategy(new JackpotSlotsStrategy());
                break;
            case SlotType.WinLose:
                context.SetStrategy(new WinLoseSlotsStrategy());
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type));
        }

        var results = context.PlayStategy(betAmount, isPictureSymbols);
        return new SlotsResult(results.result, results.payout);
    }
}