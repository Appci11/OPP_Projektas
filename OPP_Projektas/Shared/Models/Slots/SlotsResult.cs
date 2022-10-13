using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;

namespace OPP_Projektas.Shared.Models.Slots;

public class SlotsResult
{
    public SlotsResult(List<SymbolTier> slotSymbols, int payout)
    {
        SlotSymbols = slotSymbols;
        Payout = payout;
    }

    public List<SymbolTier> SlotSymbols { get; set; }
    public int Payout { get; set; }
}