using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Server.Models.Slots;

public class JackpotSlotsStrategy : ISlotStrategy
{
    private readonly Dictionary<ISymbolTier, int> payouts = new Dictionary<ISymbolTier, int>
    {
        {new TierFifth(), 10000},
    };
    public (int payout, List<ISymbolTier> result) Play(int betAmount, bool isAlternativeStyle)
    {
        var rng = new Random(Guid.NewGuid().GetHashCode());

        var number = rng.Next(15000);
        var symbolValues = new List<ISymbolTier>();
        var payout = 0;

        if (number >= 14500)
        {
            payout = betAmount * payouts[new TierFifth()];
            symbolValues = new List<ISymbolTier> { new TierFifth(), new TierFifth(), new TierFifth() };
        }

        if (!symbolValues.Any())
        {
            symbolValues = new List<ISymbolTier>() { new TierFifth(), new TierFifth(), new TierFifth() };
            while (!symbolValues.Distinct().Skip(1).Any())
            {
                for(int i = 0; i < 3; i++)
                {
                    int choice = rng.Next(0, 5);
                    switch (choice)
                    {
                        case 0:
                            symbolValues[i] = new TierFirst();
                            break;
                        case 1:
                            symbolValues[i] = new TierSecond();
                            break;
                        case 2:
                            symbolValues[i] = new TierThird();
                            break;
                        case 3:
                            symbolValues[i] = new TierFourth();
                            break;
                        case 4:
                            symbolValues[i] = new TierFifth();
                            break;
                    }
                }
            }
        }

        return (payout, symbolValues);
    }
}