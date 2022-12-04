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
        //return (ColorSymbol)this.MemberwiseClone();
        return this;
    }
    public ISlotSymbol DeepClone()
    {
        var clone = (ColorSymbol)this.MemberwiseClone();
        switch (SymbolTier)
        {
            case TierFirst:
                clone.SymbolTier = new TierFirst();
                break;
            case TierSecond:
                clone.SymbolTier = new TierSecond();
                break;
            case TierThird:
                clone.SymbolTier = new TierThird();
                break;
            case TierFourth:
                clone.SymbolTier = new TierFourth();
                break;
            case TierFifth:
                clone.SymbolTier = new TierFifth();
                break;
        }
        return clone;
    }
}