using OPP_Projektas.Shared.Models.BlackJack;

namespace OPP_Projektas.Shared.Models;

public class BlackJackDealer : Player
{
    public override void ChooseAction()
    {
        throw new NotImplementedException();
    }

    public List<BlackJackCard> Cards { get; set; } = new();
}