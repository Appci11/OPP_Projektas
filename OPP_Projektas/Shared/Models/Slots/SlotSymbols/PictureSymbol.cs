using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Shared.Models.Slots.SlotSymbols;

public class PictureSymbol : ISlotSymbol
{
    public SymbolTier SymbolTier { get; set; }
    public PictureSymbol(PictureSymbol obj)
    {
        this.SymbolTier = obj.SymbolTier;
    }
    public PictureSymbol(SymbolTier tier)
    {
        this.SymbolTier = tier;
    }

    public string Render()
    {
        switch (SymbolTier)
        {
            case SymbolTier.First:
                return "background-color: #fff; background-image: url('assets/1-first.svg'); width: 100px; height: 100px; margin: 10px;";
            case SymbolTier.Second:
                return "background-color: #fff; background-image: url('assets/2-second.svg'); width: 100px; height: 100px; margin: 10px;";
            case SymbolTier.Third:
                return "background-color: #fff; background-image: url('assets/3-third.svg'); width: 100px; height: 100px; margin: 10px;";
            case SymbolTier.Fourth:
                return "background-color: #fff; background-image: url('assets/4-fourth.svg'); width: 100px; height: 100px; margin: 10px;";
            case SymbolTier.Fifth:
                return "background-color: #fff; background-image: url('assets/5-fifth.svg'); width: 100px; height: 100px; margin: 10px;";
            default:
                return "background-color: #FFFFFF; width: 100px; height: 100px; margin: 10px;";
        }
    }
    public ISlotSymbol Clone()
    {
        return new PictureSymbol(this);
    }
}