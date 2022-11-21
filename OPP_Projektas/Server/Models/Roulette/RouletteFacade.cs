using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Services.RouletteServices;

namespace OPP_Projektas.Server.Models.Roulette
{
    public class RouletteFacade
    {
        private  IRouletteServices _rouletteServices = new RouletteServices();
        private RouletteChipMover ChipMover;
        private RouletteMessagesCreator _messagesCreator = new RouletteMessagesCreator();
        private List<RouletteUser> _users;
        private int rolledIndex;

        public RouletteFacade(List<RouletteUser> users)
        {
            _users = users;
        }

        public int GetRolledNumberIndex()
        {
            Random rand = new Random();
            rolledIndex = rand.Next(0, 36);
            //_rouletteServices.SendLogToServer(DateTime.Now.ToString() + " rolled index " + rolledIndex);
            ChipMover = new RouletteChipMover(_users, rolledIndex);
            return rolledIndex;
        }

        public int CalculateChips()
        {
            int chipsGained = ChipMover.DecideChipMovement();
            _rouletteServices.AddMessage(DateTime.Now.ToString() + " Chips gained " + chipsGained);
            return chipsGained;
        }

        public List<string> GenerateMessages()
        {            
            return _messagesCreator.FormMessages(_users);
        }
    }
}
