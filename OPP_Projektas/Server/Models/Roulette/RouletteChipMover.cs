using OPP_Projektas.Shared.Models.Roulette;
using OPP_Projektas.Server.Models.Roulette.Visitor;


namespace OPP_Projektas.Server.Models.Roulette
{
    public class RouletteChipMover
    {
        private List<RouletteUser> _users;
        private readonly int _winningIndex;
        Wheel Wheel = new Wheel();

        //galejo but ir enum, bet tingiu
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
            if (winningNumber >= 0 && winningNumber <= 12) winningThird = 1;  //3 if nesamone
            if (winningNumber >= 13 && winningNumber <= 24) winningThird = 2;//bet tingiu saziningai daryt
            if (winningNumber >= 25) winningThird = 3;

            foreach (RouletteUser user in _users)
            {
                IComponent component = new ConcreteComponent(user.BetAmmount);

                switch (user.BetType)
                {
                    // nepraziopsot, kad tarkim jei laimi 2:1 tai:
                    // zaidejui suma padvigubeja
                    // stalas praranda 1, del to atimt statyma is sk
                    case 3:
                        if (user.BetValue == winningColourValue)
                        {
                            IVisitor visitor1 = new VisitorBetOnColor();
                            int sk = Visitor.Client.ClientCode(component, visitor1);
                            chipsGained -= sk - user.BetAmmount;
                            user.Winnings = sk;
                        }
                        else
                        {
                            chipsGained += user.BetAmmount;
                            user.Winnings = 0;
                        }
                        break;
                    case 2:
                        //throw new Exception($"winningIndex = {_winningIndex}");
                        if (user.BetValue == winningThird)
                        {
                            IVisitor visitor2 = new VisitorBetOnThird();
                            int sk = Visitor.Client.ClientCode(component, visitor2);
                            chipsGained -= sk - user.BetAmmount;
                            user.Winnings = sk;
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
                            IVisitor visitor3 = new VisitorBetOnNumber();
                            int sk = Visitor.Client.ClientCode(component, visitor3);
                            chipsGained -= sk - user.BetAmmount;
                            user.Winnings = sk;
                        }
                        else
                        {
                            chipsGained += user.BetAmmount;
                            user.Winnings = 0;
                        }
                        break;
                }
            }
            return chipsGained;
        }
    }
}