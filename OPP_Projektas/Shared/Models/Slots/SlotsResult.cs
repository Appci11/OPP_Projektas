using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;
using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Shared.Models.Slots;

public class SlotsResult
{
    public SlotsResult(List<ISymbolTier> slotSymbols, int payout)
    {
        SlotSymbols = slotSymbols;
        Payout = payout;
    }

    public List<ISymbolTier> SlotSymbols { get; set; }
    public int Payout { get; set; }
}