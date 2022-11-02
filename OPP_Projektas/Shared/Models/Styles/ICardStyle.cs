using System.Drawing;

namespace OPP_Projektas.Shared.Models.Styles;

/// <summary>
/// Abstract product
/// </summary>
public interface ICardStyle
{
    string RenderCardCover();
    string RenderCardBorder();
}