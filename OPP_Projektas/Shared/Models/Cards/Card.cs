using OPP_Projektas.Shared.Models.Enums.Cards;

namespace OPP_Projektas.Shared.Models.Cards;

public class Card
{
    public Suit Suit { get; set; }
    public Value FaceValue { get; set; }

    public Card(Suit suit, Value faceValue)
    {
        Suit = suit;
        FaceValue = faceValue;
    }
}