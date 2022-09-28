using OPP_Projektas.Shared.Models.Enums.Cards;

namespace OPP_Projektas.Shared.Models.BlackJack;

public class BlackJackDeck
{
    public List<BlackJackCard> Cards { get; set; }

    public BlackJackDeck(int decksInPlay)
    {
        Cards = new List<BlackJackCard>();
        for (int i = 0; i < decksInPlay; i++)
        {
            foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
            {
                foreach (var faceValue in (Value[])Enum.GetValues(typeof(Value)))
                {
                    Cards.Add(new BlackJackCard(suit, faceValue));
                }
            }
        }
        Shuffle(Cards);
    }

    public BlackJackCard Draw()
    {
        var card = Cards.First();
        Cards.RemoveAt(0);
        return card;
    }

    public static void Shuffle(List<BlackJackCard> cards)
    {
        var rng = new Random(Guid.NewGuid().GetHashCode());
        var n = cards.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            (cards[k], cards[n]) = (cards[n], cards[k]);
        }
    }
}