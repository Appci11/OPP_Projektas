namespace OPP_Projektas.Shared.Models.BlackJack;

public class BlackJackPlayer
{
    public Guid Id { get; set; }
    public int Balance { get; set; }
    public List<BlackJackCard> Cards { get; set; } = new List<BlackJackCard>();
    public int Bet { get; set; }
}