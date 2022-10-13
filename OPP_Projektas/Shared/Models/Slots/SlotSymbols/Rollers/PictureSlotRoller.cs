using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;

public class PictureSlotRoller : SlotRoller
{
    public override ISlotSymbol CreateSymbol(SymbolTier symbolTier)
    {
        return new PictureSymbol() { SymbolTier = symbolTier};
    }
}