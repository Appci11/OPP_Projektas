using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;

namespace OPP_Projektas.Server.Models.Slots;

public class Slots
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
    private readonly Dictionary<SymbolTier, int> payouts = new Dictionary<SymbolTier, int>
    {
        {SymbolTier.First, 5},
        {SymbolTier.Second, 10},
        {SymbolTier.Third, 40},
        {SymbolTier.Fourth, 160},
        {SymbolTier.Fifth, 1000},
    };

    public SlotsResult Play(int betAmount, bool isPictureSymbols)
    {
        var rng = new Random(Guid.NewGuid().GetHashCode());

        var number = rng.Next(1000 + 25) - 24;
        var symbolValues = new List<SymbolTier>();
        var payout = 0;

        if (number >= 999)
        {
            payout = betAmount * payouts[SymbolTier.Fifth];
            symbolValues = new List<SymbolTier> { SymbolTier.Fifth, SymbolTier.Fifth, SymbolTier.Fifth };
        }
        if (number >= 995)
        {
            payout = betAmount * payouts[SymbolTier.Fourth];
            symbolValues = new List<SymbolTier> { SymbolTier.Fourth, SymbolTier.Fourth, SymbolTier.Fourth };
        }
        if (number >= 990)
        {
            payout = betAmount * payouts[SymbolTier.Third];
            symbolValues = new List<SymbolTier> { SymbolTier.Third, SymbolTier.Third, SymbolTier.Third };
        }
        if (number >= 950)
        {
            payout = betAmount * payouts[SymbolTier.Second];
            symbolValues = new List<SymbolTier> { SymbolTier.Second, SymbolTier.Second, SymbolTier.Second };
        }
        if (number == 800)
        {
            payout = betAmount * payouts[SymbolTier.First];
            symbolValues = new List<SymbolTier> {SymbolTier.First, SymbolTier.First, SymbolTier.First};
        } 
        
        
        
        

        if (!symbolValues.Any())
        {
            symbolValues = new List<SymbolTier>() {SymbolTier.Fifth, SymbolTier.Fifth, SymbolTier.Fifth};
            while (!symbolValues.Distinct().Skip(1).Any())
            {
                symbolValues = new List<SymbolTier>
                    {(SymbolTier) rng.Next(0, 5), (SymbolTier) rng.Next(0, 5), (SymbolTier) rng.Next(0, 5)};
            }
        }

        var slotSymbols = new List<ISlotSymbol>();
        SlotRoller roller;
        if (isPictureSymbols)
        {
            roller = new PictureSlotRoller();
        }
        else
        {
            roller = new ColorSlotRoller();
        }

        for (int i = 0; i < 3; i++)
        {
            slotSymbols.Add(roller.CreateSymbol(symbolValues[i]));
        }

        return new SlotsResult(symbolValues, payout);
    }
}