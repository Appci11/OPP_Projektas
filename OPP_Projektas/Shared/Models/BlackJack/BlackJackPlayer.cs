using OPP_Projektas.Shared.Models.Observer;

namespace OPP_Projektas.Shared.Models.BlackJack;

public class BlackJackPlayer : Subject
{
    private Guid _id;
    private int _balance;
    private List<BlackJackCard> _cards = new List<BlackJackCard>();
    private int _bet;

    public Guid Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public int Balance
    {
        get => _balance;
        set
        {
            _balance = value;
            OnPropertyChanged(nameof(Balance));
        }
    }

    public List<BlackJackCard> Cards
    {
        get => _cards;
        set
        {
            _cards = value;
            OnPropertyChanged(nameof(Cards));
        }
    }

    public int Bet
    {
        get => _bet;
        set
        {
            _bet = value;
            OnPropertyChanged(nameof(Bet));   
        }
    }
}