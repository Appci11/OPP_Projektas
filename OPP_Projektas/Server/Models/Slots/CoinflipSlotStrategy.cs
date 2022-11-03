using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Server.Models.Slots;

public class CoinflipSlotStrategy : ISlotStrategy
{
    private readonly Dictionary<SymbolTier, int> payouts = new Dictionary<SymbolTier, int>
    {
        {SymbolTier.First, 2},
        {SymbolTier.Second, 0},
    };

    public (int payout, List<SymbolTier> result) Play(int betAmount, bool isAlternativeStyle)
    {
        var rng = new Random(Guid.NewGuid().GetHashCode());

        var number = rng.Next(100);
        List<SymbolTier> symbolValues;
        var payout = 0;

        if (number <= 48)
        {
            payout = betAmount * payouts[SymbolTier.First];
            symbolValues = new List<SymbolTier> { SymbolTier.First, SymbolTier.First, SymbolTier.First };
        }
        else
        {
            payout = betAmount * payouts[SymbolTier.Second];
            symbolValues = new List<SymbolTier> { SymbolTier.Second, SymbolTier.Second, SymbolTier.Second };
        }

        return (payout, symbolValues);
    }
}