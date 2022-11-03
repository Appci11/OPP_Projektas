using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;
using OPP_Projektas.Shared.Models.Slots.SymbolTiers;

namespace OPP_Projektas.Server.Models.Slots;

public interface ISlotStrategy
{
    public (int payout, List<ISymbolTier> result) Play(int betAmount, bool isAlternativeStyle);
}