using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Server.Models.Slots;

public class JackpotSlotsStrategy : ISlotStrategy
{
    private readonly Dictionary<SymbolTier, int> payouts = new Dictionary<SymbolTier, int>
    {
        {SymbolTier.Fifth, 10000},
    };
    public (int payout, List<SymbolTier> result) Play(int betAmount, bool isAlternativeStyle)
    {
        var rng = new Random(Guid.NewGuid().GetHashCode());

        var number = rng.Next(15000);
        var symbolValues = new List<SymbolTier>();
        var payout = 0;

        if (number >= 14500)
        {
            payout = betAmount * payouts[SymbolTier.Fifth];
            symbolValues = new List<SymbolTier> { SymbolTier.Fifth, SymbolTier.Fifth, SymbolTier.Fifth };
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