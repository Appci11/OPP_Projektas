namespace OPP_Projektas.Shared.Models.HoldemPoker;

public class HoldemDeck
{
    public List<HoldemCard> Cards { get; set; }

    public HoldemDeck()
    {
        Cards = new List<HoldemCard>();
    }

    public void Add(HoldemCard card)
    {
        Cards.Add(card);
    }
}