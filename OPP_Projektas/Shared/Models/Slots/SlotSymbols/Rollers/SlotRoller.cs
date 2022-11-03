using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols.Rollers;

public abstract class SlotRoller
{
    public abstract ISlotSymbol CreateSymbol(int tier);
    public abstract ISlotSymbol CreateSymbol(ISymbolTier tier);

    public string Render(int tier)
    {
        var symbol = CreateSymbol(tier);

        return symbol.Render();
    }
    public string Render(ISymbolTier tier)
    {
        var symbol = CreateSymbol(tier);

        return symbol.Render();
    }
}