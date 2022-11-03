using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols;

public interface ISlotSymbol
{
    public ISymbolTier SymbolTier { get; set; }
    public string Render();
    public ISlotSymbol ShallowClone()
    {
        return this.ShallowClone();
    }
    public ISlotSymbol DeepClone()
    {
        return this.DeepClone();
    }
}