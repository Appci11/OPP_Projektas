using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;

public class ColorSlotRoller : SlotRoller
{
    public override ISlotSymbol CreateSymbol(SymbolTier symbolTier)
    {
        return new ColorSymbol() { SymbolTier = symbolTier };
    }
}