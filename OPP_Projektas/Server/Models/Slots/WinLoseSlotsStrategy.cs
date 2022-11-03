using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Server.Models.Slots;

public class WinLoseSlotsStrategy : ISlotStrategy
{
    private readonly Dictionary<SymbolTier, int> payouts = new Dictionary<SymbolTier, int>
    {
        {SymbolTier.First, 5},
        {SymbolTier.Second, 2},
        {SymbolTier.Third, 1},
        {SymbolTier.Fourth, -2},
        {SymbolTier.Fifth, -5},
    };

    public (int payout, List<SymbolTier> result) Play(int betAmount, bool isAlternativeStyle)
    {
        var rng = new Random(Guid.NewGuid().GetHashCode());

        var number = rng.Next(1000 + 25) - 24;
        var symbolValues = new List<SymbolTier>();
        var payout = 0;

        if (number >= 900)
        {
            payout = betAmount * payouts[SymbolTier.First];
            symbolValues = new List<SymbolTier> { SymbolTier.First, SymbolTier.First, SymbolTier.First };
        }
        else if (number >= 750)
        {
            payout = betAmount * payouts[SymbolTier.Second];
            symbolValues = new List<SymbolTier> { SymbolTier.Second, SymbolTier.Second, SymbolTier.Second };
        }
        else if (number <= 110)
        {
            payout = betAmount * payouts[SymbolTier.Fifth];
            symbolValues = new List<SymbolTier> { SymbolTier.Fifth, SymbolTier.Fifth, SymbolTier.Fifth };
        }
        else if (number <= 270)
        {
            payout = betAmount * payouts[SymbolTier.Fourth];
            symbolValues = new List<SymbolTier> { SymbolTier.Fourth, SymbolTier.Fourth, SymbolTier.Fourth };
        }
        else
        {
            payout = betAmount * payouts[SymbolTier.Third];
            symbolValues = new List<SymbolTier> { SymbolTier.Third, SymbolTier.Third, SymbolTier.Third };
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