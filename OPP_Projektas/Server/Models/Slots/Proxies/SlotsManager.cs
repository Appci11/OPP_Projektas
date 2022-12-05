using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots;

namespace OPP_Projektas.Server.Models.Slots.Proxies;

public class SlotsManager : ISlots
{
    private readonly ISlots _slots;

    public SlotsManager()
    {
        _slots = Slots.GetInstance();
    }

    public SlotsResult Play(int betAmount, bool isPictureSymbols, SlotType type)
    {
        return _slots.Play(betAmount, isPictureSymbols, type);
    }
}