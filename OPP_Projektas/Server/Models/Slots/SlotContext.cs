using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;

namespace OPP_Projektas.Server.Models.Slots;

public class SlotContext
{
    private ISlotStrategy _strategy;

    public void SetStrategy(ISlotStrategy strategy)
    {
        _strategy = strategy;
    }

    public (int payout, List<SymbolTier> result) PlayStategy(int betAmount, bool isAlternativeStyle)
    {
        return _strategy.Play(betAmount, isAlternativeStyle);
    }
}