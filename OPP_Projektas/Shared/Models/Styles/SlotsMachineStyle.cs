using System.Drawing;

namespace OPP_Projektas.Shared.Models.Styles;

/// <summary>
/// Concrete product
/// </summary>
public class SlotsMachineStyle : ISlotsMachineStyle
{
    private readonly Color _color;

    public SlotsMachineStyle(Color color)
    {
        _color = color;
    }

    public string RenderBorder() => $"border: 5px solid {_color.Name}";
}