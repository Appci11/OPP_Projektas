//susikurus hub'a nepamirst in program.cs route'a suteikt
//visa kita vienkartinis prijungimas ir jau prideta

using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.Roulette;
using OPP_Projektas.Server.Services.RouletteServices;
using OPP_Projektas.Shared.Models.Chat;
using OPP_Projektas.Shared.Models.Roulette;
using OPP_Projektas.Shared.Models.Roulette.Iterator;
using System.Security.Cryptography;

namespace OPP_Projektas.Server.GameHubs
{
    //nepamirst paveldet Hub
    public class RouletteHub : Hub
    {
        static MyIterableCollection myCollection = new MyIterableCollection();
        static ChipsKeeper ChipsKeeper = new ChipsKeeper();
        RouletteFacade Facade = new RouletteFacade(Users);
        //prisijungusiu user'iu rinkinys
        Wheel Wheel = new Wheel();
        private static List<RouletteUser> Users = new List<RouletteUser>();
        static int betsCount = 0;
        static int gameNr = 0;
        static int oldBalance = 1000;

        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            //Users.Add(Context.ConnectionId, new RouletteUser(username));
            Users.Add(new RouletteUser(Context.ConnectionId, username));
            //await AddConnectionStatusMsg(string.Empty, "User connected!");

            await AddConnectionStatusMsg($"{username} joined the game!");
            await Clients.All.SendAsync("GetPlayerCount", Users.Count);
            await Clients.All.SendAsync("GetBetsPlacedCount", betsCount);

            myCollection.AddUser(username);
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

        public async Task PlaceABetRed(int BetAmmount, int betValue)
        {
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetAmmount = BetAmmount;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).Bet = "Red";
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetType = 3;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetValue = betValue;
            await Clients.All.SendAsync("GetBetsPlacedCount", ++betsCount);
            if (betsCount >= Users.Count)
            {
                await RollANumber();
            }
        }
        public async Task PlaceABetBlack(int BetAmmount, int betValue)
        {
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetAmmount = BetAmmount;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).Bet = "Black";
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetType = 3;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetValue = betValue;
            await Clients.All.SendAsync("GetBetsPlacedCount", ++betsCount);
            if (betsCount >= Users.Count)
            {
                await RollANumber();
            }
        }

        public async Task PlaceABetThird(int BetAmmount, int betValue)
        {
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetAmmount = BetAmmount;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetType = 2;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetValue = betValue;
            await Clients.All.SendAsync("GetBetsPlacedCount", ++betsCount);
            if (betsCount >= Users.Count)
            {
                await RollANumber();
            }
        }

        public async Task PlaceABetNumber(int BetAmmount, int betValue)
        {
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetAmmount = BetAmmount;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetType = 1;
            Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).BetValue = betValue;
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
            foreach (string message in Facade.GenerateMessages())
            {
                await Clients.All.SendAsync("GetMessage", message);
            }
        }

        public async Task SendWinnings()
        {
            int diff = ChipsKeeper.Chips - oldBalance;
            oldBalance = ChipsKeeper.Chips;
            myCollection.AddToLog($"Game nr: {++gameNr}  Table Chips gain: {diff}");
            foreach (RouletteUser user in Users)
            {
                await Clients.Client(user.GameId).SendAsync("GetWinnings", user.Winnings);
            }
        }

        public async Task SendLog()
        {
            myCollection.SetStats(ChipsKeeper.Chips, Users.Count);
            List<string> result = new List<string>();
            foreach (string kriu in myCollection)
            {
                result.Add(kriu);
            }
            await Clients.Client(Context.ConnectionId).SendAsync("GetLog", result);
        }

        public async Task GetCommandMessage(string cmdMessage)
        {
            //await Clients.All.SendAsync("GetMessage", "Some1 sent command message: " + cmdMessage);
            await Clients.Client(Context.ConnectionId).SendAsync("GetMessage", "I sent command message: " + cmdMessage);

            //visiem issiuncia po 100
            //foreach (RouletteUser user in Users)
            //{
            //    await Clients.Client(user.GameId).SendAsync("GetWinnings", 100);
            //}


            //zinutes siuntejui issiuncia 100
            //veikia ir su -100, jei tarkim sumastom persiust zetonus kitam zaidejui ar grupei
            //await Clients.Client(Context.ConnectionId).SendAsync("GetWinnings", 100);

            //zinutes siuntejui
            //await Clients.Client(Context.ConnectionId).SendAsync("GetMessage", "Player count: " + Users.Count);

            //dar sitas gali pravers jei pagal username kazko ieskom
            //tarkim kitam zaidejui persiust zetonus uzsimanom
            // by id, get username (is kur is anksto zinotum id neisivaizduoju, gal kokiam adminui praverstu)
            //string username = Users.FirstOrDefault(u => u.GameId == Context.ConnectionId).Username;
            // by username, get id
            //string userId = Users.FirstOrDefault(u => u.Username == cmdMessage).GameId;
            //if (userId != null) await Clients.Client(Context.ConnectionId).SendAsync("GetMessage", userId);
        }
    }
}
