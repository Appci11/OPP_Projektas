using OPP_Projektas.Shared.Models.Cards.Interfaces;
using OPP_Projektas.Shared.Models.Enums.Cards;

namespace OPP_Projektas.Shared.Models.HoldemPoker;

public class HoldemSetBuilder : ISetBuilder
{
    private HoldemDeck _holdemDeck = new();

    public HoldemSetBuilder()
    {
        Reset();
    }

    private void Reset()
    {
        _holdemDeck = new HoldemDeck();
    }

    public void AddAces()
    {
        foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
        {
            _holdemDeck.Add(new HoldemCard(suit, Value.Ace));
        }
    }

    public void AddKings()
    {
        foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
        {
            _holdemDeck.Add(new HoldemCard(suit, Value.King));
        }
    }

    public void AddQueens()
    {
        foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
        {
            _holdemDeck.Add(new HoldemCard(suit, Value.Queen));
        }
    }

    public void AddJacks()
    {
        foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
        {
            _holdemDeck.Add(new HoldemCard(suit, Value.Jack));
        }
    }

    public void AddNumbers()
    {
        for (var i = 0; i < 9; i++)
        {
            foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
            {
                _holdemDeck.Add(new HoldemCard(suit, (Value)i));
            }
        }
    }

    public HoldemDeck GetHoldemDeck()
    {
        var result = _holdemDeck;
        Reset();

        return result;
    }
}