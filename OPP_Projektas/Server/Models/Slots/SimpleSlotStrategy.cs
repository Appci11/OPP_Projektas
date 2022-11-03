using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;

namespace OPP_Projektas.Server.Models.Slots;

public class SimpleSlotStrategy : ISlotStrategy
{
    private readonly Dictionary<SymbolTier, int> payouts = new Dictionary<SymbolTier, int>
    {
        {SymbolTier.First, 5},
        {SymbolTier.Second, 10},
        {SymbolTier.Third, 40},
        {SymbolTier.Fourth, 160},
        {SymbolTier.Fifth, 1000},
    };

    public (int payout, List<SymbolTier> result) Play(int betAmount, bool isAlternativeStyle)
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
        if (number >= 800)
        {
            payout = betAmount * payouts[SymbolTier.First];
            symbolValues = new List<SymbolTier> { SymbolTier.First, SymbolTier.First, SymbolTier.First };
        }

        if (!symbolValues.Any())
        {
            symbolValues = new List<SymbolTier>() { SymbolTier.Fifth, SymbolTier.Fifth, SymbolTier.Fifth };
            while (!symbolValues.Distinct().Skip(1).Any())
            {
                symbolValues = new List<SymbolTier>
                    {(SymbolTier) rng.Next(0, 5), (SymbolTier) rng.Next(0, 5), (SymbolTier) rng.Next(0, 5)};
            }
        }

        return (payout, symbolValues);
    }
}