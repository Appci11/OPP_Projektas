using OPP_Projektas.Shared.Models.Cards;
using OPP_Projektas.Shared.Models.Enums.Cards;

namespace OPP_Projektas.Shared.Models.HoldemPoker;

public class HoldemCard : Card
{
    public HoldemCard(Suit suit, Value faceValue) : base(suit, faceValue)
    {
    }
}