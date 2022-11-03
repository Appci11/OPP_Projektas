using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;

public class ColorSlotRoller : SlotRoller
{
    public override ISlotSymbol CreateSymbol(int tier)
    {
        switch (tier)
        {
            case 1:
                return new PictureSymbol(new TierFirst());
            case 2:
                return new PictureSymbol(new TierSecond());
            case 3:
                return new PictureSymbol(new TierThird());
            case 4:
                return new PictureSymbol(new TierFourth());
            case 5:
                return new PictureSymbol(new TierFifth());
        }
        return null;
    }
    public override ISlotSymbol CreateSymbol(ISymbolTier tier)
    {
        return new ColorSymbol(tier);
    }
}