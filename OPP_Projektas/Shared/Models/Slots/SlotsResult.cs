using OPP_Projektas.Shared.Models.Enums.Slots;

namespace OPP_Projektas.Shared.Models.Slots;

public class SlotsResult
{
    public List<Symbols> Symbols { get; set; }
    public int Payout { get; set; }
}