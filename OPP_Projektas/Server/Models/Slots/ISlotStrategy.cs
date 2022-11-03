using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;

namespace OPP_Projektas.Server.Models.Slots;

public interface ISlotStrategy
{
    public (int payout, List<SymbolTier> result) Play(int betAmount, bool isAlternativeStyle);
}