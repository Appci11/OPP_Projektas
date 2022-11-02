using System.Drawing;

namespace OPP_Projektas.Shared.Models.Styles;

/// <summary>
/// Concrete factory
/// </summary>
public class BlueStyle : IStyle
{
    public ISlotsMachineStyle CreateSlotsMachineStyle() => new SlotsMachineStyle(Color.Blue);

    public ICardStyle CreateCardsStyle() => new CardStyle(Color.Blue);
}