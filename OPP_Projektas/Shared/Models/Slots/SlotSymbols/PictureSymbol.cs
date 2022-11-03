using OPP_Projektas.Shared.Models.Slots.SymbolTiers;


namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols;

public class PictureSymbol : ISlotSymbol
{
    public ISymbolTier SymbolTier { get; set; }
    public PictureSymbol(PictureSymbol obj)
    {
        this.SymbolTier = obj.SymbolTier;
    }
    public PictureSymbol(ISymbolTier tier)
    {
        this.SymbolTier = tier;
    }

    public string Render()
    {
        switch (SymbolTier)
        {
            case TierFirst:
                return "background-color: #fff; background-image: url('assets/1-first.svg'); width: 100px; height: 100px; margin: 10px;";
            case TierSecond:
                return "background-color: #fff; background-image: url('assets/2-second.svg'); width: 100px; height: 100px; margin: 10px;";
            case TierThird:
                return "background-color: #fff; background-image: url('assets/3-third.svg'); width: 100px; height: 100px; margin: 10px;";
            case TierFourth:
                return "background-color: #fff; background-image: url('assets/4-fourth.svg'); width: 100px; height: 100px; margin: 10px;";
            case TierFifth:
                return "background-color: #fff; background-image: url('assets/5-fifth.svg'); width: 100px; height: 100px; margin: 10px;";
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
        return new PictureSymbol(this);
    }
}