using System.Drawing;

namespace OPP_Projektas.Shared.Models.Styles;

public class DefaultStyle : IStyle
{
    public ISlotsMachineStyle CreateSlotsMachineStyle() => new SlotsMachineStyle(Color.Black);

    public ICardStyle CreateCardsStyle() => new CardStyle(Color.Black);
}