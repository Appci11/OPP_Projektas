using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;

namespace OPP_Projektas.Shared.Models.Slots;

public class SlotsResult
{
    public List<ISlotSymbol> SlotSymbols { get; set; }
    public int Payout { get; set; }
}