using System.Drawing;

namespace OPP_Projektas.Shared.Models.Styles;

/// <summary>
/// Concrete product
/// </summary>
public class CardStyle : ICardStyle
{
    private readonly Color _color;

    public CardStyle(Color color)
    {
        _color = color;
    }

    public string RenderCardCover() => $"background-color: {_color.Name}; width: 100px; height: 100px; margin: 10px;";
    public string RenderCardBorder() => $"border: 2px solid {_color.Name}";
}