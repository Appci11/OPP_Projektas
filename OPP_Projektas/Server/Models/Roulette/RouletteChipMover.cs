using OPP_Projektas.Shared.Models.Roulette;
using System;
using System.Linq.Expressions;

namespace OPP_Projektas.Server.Models.Roulette
{
    public class RouletteChipMover
    {
        private List<RouletteUser> _users;
        private readonly int _winningIndex;
        Wheel Wheel = new Wheel();

        int winningNumber = 0;
        int winningThird = 0;
        int winningColourValue = 0;
        string winningColour = String.Empty;

        public RouletteChipMover(List<RouletteUser> users, int winningIndex)
        {
            _users = users;
            _winningIndex = winningIndex;
        }
        public int DecideChipMovement()
        {
            int chipsGained = 0;
            winningColour = Wheel.WheelNumbers[_winningIndex].Colour.ToString();
            if (string.Compare(winningColour, "Red") == 0) { winningColourValue = 1; }
            else { winningColourValue = 2; }
            winningNumber = Wheel.WheelNumbers[_winningIndex].Number;
            if (winningNumber >= 0 && winningNumber <= 12) winningThird = 1;  //nesamone
            if (winningNumber >= 13 && winningNumber <= 24) winningThird = 2;//bet tingiu
            if (winningNumber >= 25) winningThird = 3;

            foreach (RouletteUser user in _users)
            {
                switch (user.BetType)
                {
                    case 3:
                        if (user.BetValue == winningColourValue)
                        {
                            chipsGained -= user.BetAmmount;
                            user.Winnings = user.BetAmmount * 2;
                        }
                        else
                        {
                            chipsGained += user.BetAmmount;
                            user.Winnings = 0;
                        }
                        break;
                    case 2:
                        if (user.BetValue == winningThird)
                        {
                            chipsGained -= user.BetAmmount * 2;
                            user.Winnings = user.BetAmmount * 3;
                        }
                        else
                        {
                            chipsGained += user.BetAmmount;
                            user.Winnings = 0;
                        }
                        break;
                    default:
                        if (user.BetValue == winningNumber)
                        {
                            chipsGained -= user.BetAmmount * 32;
                            user.Winnings = user.BetAmmount * 33;
                        }
                        else
                        {
                            chipsGained += user.BetAmmount;
                            user.Winnings = 0;
                        }
                        break;
                }
            }
            Console.WriteLine();
            return chipsGained;
        }
    }
}