using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots;

namespace OPP_Projektas.Server.Models.Slots.Proxies;

public class BonusSlotsManager : ISlots
{
    private readonly ISlots _slots;

    public BonusSlotsManager()
    {
        _slots = Slots.GetInstance();
    }

    public SlotsResult Play(int betAmount, bool isPictureSymbols, SlotType type)
    {
        var rng = new Random();
        if (rng.Next(10) == 0)
        {
            betAmount *= 3;
        }

        return _slots.Play(betAmount, isPictureSymbols, type);
    }
}