using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols;

public class ColorSymbol : ISlotSymbol
{
    public ISymbolTier SymbolTier { get; set; }
    public ColorSymbol(ColorSymbol obj)
    {
        this.SymbolTier = obj.SymbolTier;
    }
    public ColorSymbol(ISymbolTier tier)
    {
        Console.WriteLine("i is in color symbol constructor");
        this.SymbolTier = tier;
    }
    public string Render()
    {
        switch (SymbolTier)
        {
            case TierFirst:
                return "background-color: #0000FF; width: 100px; height: 100px; margin: 10px;";
            case TierSecond:
                return "background-color: #FF0000; width: 100px; height: 100px; margin: 10px;";
            case TierThird:
                return "background-color: #00FF00; width: 100px; height: 100px; margin: 10px;";
            case TierFourth:
                return "background-color: #FFFF00; width: 100px; height: 100px; margin: 10px;";
            case TierFifth:
                return "background-color: #FFA500; width: 100px; height: 100px; margin: 10px;";
            default:
                return "background-color: #FFFFFF; width: 100px; height: 100px; margin: 10px;";
        }
    }
    public ISlotSymbol ShallowClone()
    {
        var original = this;
        return original;
    }
    public ISlotSymbol DeepClone()
    {
        return new ColorSymbol(this);
    }
}