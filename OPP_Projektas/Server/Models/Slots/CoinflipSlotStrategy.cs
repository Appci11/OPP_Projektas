using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Server.Models.Slots;

public class CoinflipSlotStrategy : ISlotStrategy
{
    private readonly Dictionary<ISymbolTier, int> payouts = new Dictionary<ISymbolTier, int>
    {
        {new TierFirst(), 2},
        {new TierSecond(), 0},
    };

    public (int payout, List<ISymbolTier> result) Play(int betAmount, bool isAlternativeStyle)
    {
        var rng = new Random(Guid.NewGuid().GetHashCode());

        var number = rng.Next(100);
        List<ISymbolTier> symbolValues;
        var payout = 0;

        if (number <= 48)
        {
            payout = betAmount * payouts[new TierFirst()];
            symbolValues = new List<ISymbolTier> { new TierFirst(), new TierFirst(), new TierFirst() };
        }
        else
        {
            payout = betAmount * payouts[new TierSecond()];
            symbolValues = new List<ISymbolTier> { new TierSecond(), new TierSecond(), new TierSecond() };
        }

        return (payout, symbolValues);
    }
}