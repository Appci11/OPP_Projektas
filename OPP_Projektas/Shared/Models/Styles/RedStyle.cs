using System.Drawing;

namespace OPP_Projektas.Shared.Models.Styles;

/// <summary>
/// Concrete factory
/// </summary>
public class RedStyle : IStyle
{
    public ISlotsMachineStyle CreateSlotsMachineStyle() => new SlotsMachineStyle(Color.Red);

    public ICardStyle CreateCardsStyle() => new CardStyle(Color.Red);
}