using OPP_Projektas.Shared.Models.Cards.Interfaces;
using OPP_Projektas.Shared.Models.Enums.Cards;

namespace OPP_Projektas.Shared.Models.BlackJack;

public class BlackJackSetBuilder : ISetBuilder
{
    private BlackJackDeck _blackJackDeck = new();

    public BlackJackSetBuilder()
    {
        Reset();
    }

    private void Reset()
    {
        _blackJackDeck = new BlackJackDeck();
    }

    public void AddAces()
    {
        foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
        {
            _blackJackDeck.Add(new BlackJackCard(suit, Value.Ace));
        }
    }
    
    public void AddKings()
    {
        foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
        {
            _blackJackDeck.Add(new BlackJackCard(suit, Value.King));
        }
    }

    public void AddQueens()
    {
        foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
        {
            _blackJackDeck.Add(new BlackJackCard(suit, Value.Queen));
        }
    }

    public void AddJacks()
    {
        foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
        {
            _blackJackDeck.Add(new BlackJackCard(suit, Value.Jack));
        }
    }

    public void AddNumbers()
    {
        for (var i = 0; i < 9; i++)
        {
            foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
            {
                _blackJackDeck.Add(new BlackJackCard(suit, (Value)i));
            }
        }
    }

    public BlackJackDeck GetBlackJackDeck()
    {
        var result = _blackJackDeck;
        Reset();

        return result;
    }
}