namespace OPP_Projektas.Shared.Models.Styles;

/// <summary>
/// Abstract factory
/// </summary>
public interface IStyle
{
    ISlotsMachineStyle CreateSlotsMachineStyle();
    ICardStyle CreateCardsStyle();
}