using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols;

public class ColorSymbol : ISlotSymbol
{
    public SymbolTier SymbolTier { get; set; }
    public ColorSymbol(ColorSymbol obj)
    {
        this.SymbolTier = obj.SymbolTier;
    }
    public ColorSymbol(SymbolTier tier)
    {
        this.SymbolTier = tier;
    }
    public string Render()
    {
        switch (SymbolTier)
        {
            case SymbolTier.First:
                return "background-color: #0000FF; width: 100px; height: 100px; margin: 10px;";
            case SymbolTier.Second:
                return "background-color: #FF0000; width: 100px; height: 100px; margin: 10px;";
            case SymbolTier.Third:
                return "background-color: #00FF00; width: 100px; height: 100px; margin: 10px;";
            case SymbolTier.Fourth:
                return "background-color: #FFFF00; width: 100px; height: 100px; margin: 10px;";
            case SymbolTier.Fifth:
                return "background-color: #FFA500; width: 100px; height: 100px; margin: 10px;";
            default:
                return "background-color: #FFFFFF; width: 100px; height: 100px; margin: 10px;";
        }
    }
    public ISlotSymbol Clone()
    {
        return new ColorSymbol(this);
    }
}