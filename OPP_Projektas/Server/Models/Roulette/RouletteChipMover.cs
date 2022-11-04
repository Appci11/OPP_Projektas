using OPP_Projektas.Shared.Models.Roulette;

namespace OPP_Projektas.Server.Models.Roulette
{
    public class RouletteChipMover
    {
        private List<RouletteUser> _users;
        private readonly int _winningIndex;
        Wheel Wheel = new Wheel();

        public RouletteChipMover(List<RouletteUser> users, int winningIndex)
        {
            _users = users;
            _winningIndex = winningIndex;
        }
        public int DecideChipMovement()
        {
            int chipsGained = 0;
            string winningColour = Wheel.WheelNumbers[_winningIndex].Colour.ToString();
            foreach (RouletteUser user in _users)
            {
                if (string.Compare(winningColour, user.Bet) == 0)
                {
                    chipsGained -= user.BetAmmount;
                    user.Winnings = user.BetAmmount * 2;
                }
                else
                {
                    chipsGained += user.BetAmmount;
                    user.Winnings = 0;
                }
            }
            Console.WriteLine();
            return chipsGained;
        }
    }
}