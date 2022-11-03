using OPP_Projektas.Shared.Models.Observer;

namespace OPP_Projektas.Shared.Models.BlackJack;

public class BlackJackPlayer : Subject
{
    private int _bet;
    public Guid Id { get; set; }
    public int Balance { get; set; }
    public List<BlackJackCard> Cards { get; set; } = new List<BlackJackCard>();

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