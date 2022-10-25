using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols;

public interface ISlotSymbol
{
    public SymbolTier SymbolTier { get; set; }
    public string Render();
    public ISlotSymbol Clone()
    {
        return this.Clone();
    }
}