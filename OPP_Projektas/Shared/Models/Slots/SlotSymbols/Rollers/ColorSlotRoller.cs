using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;

public class ColorSlotRoller : SlotRoller
{
    public override ISlotSymbol CreateSymbol(int tier)
    {
        switch (tier)
        {
            case 1:
                return new ColorSymbol(new TierFirst());
            case 2:
                return new ColorSymbol(new TierSecond());
            case 3:
                return new ColorSymbol(new TierThird());
            case 4:
                return new ColorSymbol(new TierFourth());
            case 5:
                return new ColorSymbol(new TierFifth());
        }
        return null;
    }
    public override ISlotSymbol CreateSymbol(ISymbolTier tier)
    {
        Console.WriteLine("i is in create symbol");
        return new ColorSymbol(tier);
    }
}