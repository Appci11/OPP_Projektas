//susikurus hub'a nepamirst in program.cs route'a suteikt
//visa kita vienkartinis prijungimas ir jau prideta

using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.Roulette;
using OPP_Projektas.Shared.Models.Chat;
using OPP_Projektas.Shared.Models.Roulette;

namespace OPP_Projektas.Server.GameHubs
{
    //nepamirst paveldet Hub
    public class RouletteHub : Hub
    {
        ChipsKeeper ChipsKeeper = new ChipsKeeper();
        RouletteFacade Facade = new RouletteFacade(Users);
        //prisijungusiu user'iu rinkinys
        Wheel Wheel = new Wheel();
        private static List<RouletteUser> Users = new List<RouletteUser>();
        static int betsCount = 0;       

        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            //Users.Add(Context.ConnectionId, new RouletteUser(username));
            Users.Add(new RouletteUser(Context.ConnectionId, username));
            //await AddConnectionStatusMsg(string.Empty, "User connected!");

            await AddConnectionStatusMsg($"{username} joined the game!");
            await Clients.All.SendAsync("GetPlayerCount", Users.Count);
            await Clients.All.SendAsync("GetBetsPlacedCount", betsCount);

            //needed by default, ne mano ismislas
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string username = Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).Username;
            await AddConnectionStatusMsg($"{username} left the game!");
            //Users.Remove(Context.ConnectionId);
            int index = Users.FindIndex(u => u.GameId == Context.ConnectionId);
            Users.RemoveAt(index);
            await Clients.All.SendAsync("GetPlayerCount", Users.Count);
            await Clients.All.SendAsync("GetBetsPlacedCount", betsCount);
            
            if (betsCount >= Users.Count)
            {
                await RollANumber();
            }
        }

        public async Task AddConnectionStatusMsg(string message)
        {
            await Clients.All.SendAsync("GetMessage", message);
        }

        public async Task SendPlayerCount()
        {
            await Clients.All.SendAsync("GetPlayerCount", Users.Count);
        }

        public async Task PlaceABetRed(int BetAmmount)
        {
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetAmmount = BetAmmount;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).Bet = "Red";
            await Clients.All.SendAsync("GetBetsPlacedCount", ++betsCount);
            if (betsCount >= Users.Count)
            {
                await RollANumber();
            }
        }
        public async Task PlaceABetBlack(int BetAmmount)
        {
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetAmmount = BetAmmount;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).Bet = "Black";
            await Clients.All.SendAsync("GetBetsPlacedCount", ++betsCount);
            if (betsCount >= Users.Count)
            {
                await RollANumber();
            }
        }

        public async Task RollANumber()
        {
            int rolledNumberIndex = Facade.GetRolledNumberIndex();
            ChipsKeeper.Chips += Facade.CalculateChips();
            await Clients.All.SendAsync("GetRolledNumberIndex", rolledNumberIndex);
            betsCount = 0;
            await Clients.All.SendAsync("GetBetsPlacedCount", betsCount);
            await Clients.All.SendAsync("GetMessage", $"Rolled #{Wheel.WheelNumbers[rolledNumberIndex].Number}");
            await SendMessages();
            await SendWinnings();
        }

        public async Task SendMessages()
        {
            foreach(string message in Facade.GenerateMessages())
            {
                await Clients.All.SendAsync("GetMessage", message);
            }
        }

        public async Task SendWinnings()
        {
            foreach (RouletteUser user in Users)
            {
                await Clients.Client(user.GameId).SendAsync("GetWinnings", user.Winnings);
                Console.WriteLine();
            }
        }
    }
}
