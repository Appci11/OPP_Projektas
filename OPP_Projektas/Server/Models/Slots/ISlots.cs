using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots;

namespace OPP_Projektas.Server.Models.Slots;

public interface ISlots
{
    SlotsResult Play(int betAmount, bool isPictureSymbols, SlotType type);
}