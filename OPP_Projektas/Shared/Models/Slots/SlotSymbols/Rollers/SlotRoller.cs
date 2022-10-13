using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;

public abstract class SlotRoller
{
    public abstract ISlotSymbol CreateSymbol(SymbolTier symbolTier);

    public string Render(SymbolTier symbolTier)
    {
        var symbol = CreateSymbol(symbolTier);

        return symbol.Render();
    }
}