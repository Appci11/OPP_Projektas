using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;
using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Server.Models.Slots;

public class SimpleSlotStrategy : ISlotStrategy
{
    private readonly Dictionary<ISymbolTier, int> payouts = new Dictionary<ISymbolTier, int>
    {
        {new TierFirst(), 5},
        {new TierSecond(), 10},
        {new TierThird(), 40},
        {new TierFourth(), 160},
        {new TierFifth(), 1000},
    };

    public (int payout, List<ISymbolTier> result) Play(int betAmount, bool isAlternativeStyle)
    {
        
        var rng = new Random(Guid.NewGuid().GetHashCode());

        var number = rng.Next(1000 + 25) - 24;
        var symbolValues = new List<ISymbolTier>();
        var payout = 0;

        if (number >= 999)
        {
            payout = betAmount * payouts[new TierFifth()];
            symbolValues = new List<ISymbolTier> { new TierFifth(), new TierFifth(), new TierFifth() };
        }
        if (number >= 995)
        {
            payout = betAmount * payouts[new TierFourth()];
            symbolValues = new List<ISymbolTier> { new TierFourth(), new TierFourth(), new TierFourth() };
        }
        if (number >= 990)
        {
            payout = betAmount * payouts[new TierThird()];
            symbolValues = new List<ISymbolTier> { new TierThird(), new TierThird(), new TierThird() };
        }
        if (number >= 950)
        {
            payout = betAmount * payouts[new TierSecond()];
            symbolValues = new List<ISymbolTier> { new TierSecond(), new TierSecond(), new TierSecond() };
        }
        if (number >= 800)
        {
            payout = betAmount * payouts[new TierFirst()];
            symbolValues = new List<ISymbolTier> { new TierFirst(), new TierFirst(), new TierFirst() };
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