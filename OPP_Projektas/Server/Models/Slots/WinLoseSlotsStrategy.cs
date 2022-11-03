using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Server.Models.Slots;

public class WinLoseSlotsStrategy : ISlotStrategy
{
    private readonly Dictionary<ISymbolTier, int> payouts = new Dictionary<ISymbolTier, int>
    {
        {new TierFirst(), 5},
        {new TierSecond(), 2},
        {new TierThird(), 1},
        {new TierFourth(), -2},
        {new TierFifth(), -5},
    };

    public (int payout, List<ISymbolTier> result) Play(int betAmount, bool isAlternativeStyle)
    {
        var rng = new Random(Guid.NewGuid().GetHashCode());

        var number = rng.Next(1000 + 25) - 24;
        var symbolValues = new List<ISymbolTier>();
        var payout = 0;

        if (number >= 900)
        {
            payout = betAmount * payouts[new TierFirst()];
            symbolValues = new List<ISymbolTier> { new TierFirst(), new TierFirst(), new TierFirst() };
        }
        else if (number >= 750)
        {
            payout = betAmount * payouts[new TierSecond()];
            symbolValues = new List<ISymbolTier> { new TierSecond(), new TierSecond(), new TierSecond() };
        }
        else if (number <= 110)
        {
            payout = betAmount * payouts[new TierFifth()];
            symbolValues = new List<ISymbolTier> { new TierFifth(), new TierFifth(), new TierFifth() };
        }
        else if (number <= 270)
        {
            payout = betAmount * payouts[new TierFourth()];
            symbolValues = new List<ISymbolTier> { new TierFourth(), new TierFourth(), new TierFourth() };
        }
        else
        {
            payout = betAmount * payouts[new TierThird()];
            symbolValues = new List<ISymbolTier> { new TierThird(), new TierThird(), new TierThird() };
        }

        if (!symbolValues.Any())
        {
            symbolValues = new List<ISymbolTier>() { new TierFifth(), new TierFifth(), new TierFifth() };
            while (!symbolValues.Distinct().Skip(1).Any())
            {
                for (int i = 0; i < 3; i++)
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