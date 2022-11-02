namespace OPP_Projektas.Shared.Models.BlackJack;

public class BlackJackDeck
{
    public List<BlackJackCard> Cards { get; set; }
    
    public BlackJackDeck()
    {
        Cards = new List<BlackJackCard>();
    }

    public void Add(BlackJackCard card)
    {
        Cards.Add(card);
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