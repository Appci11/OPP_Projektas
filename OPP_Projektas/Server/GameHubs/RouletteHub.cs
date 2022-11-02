//susikurus hub'a nepamirst in program.cs route'a suteikt
//visa kita vienkartinis prijungimas ir jau prideta

using Microsoft.AspNetCore.SignalR;

namespace OPP_Projektas.Server.GameHubs
{
    //nepamirst paveldet Hub
    public class RouletteHub : Hub
    {
        //prisijungusiu user'iu rinkinys
        private static Dictionary<string, string> Users = new Dictionary<string, string>();

        static bool TableHasPlayers = false;
        static int betsCount = 0;

        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            Users.Add(Context.ConnectionId, username);
            //await AddConnectionStatusMsg(string.Empty, "User connected!");
            
            await AddConnectionStatusMsg($"{username} joined the game!");
            await Clients.All.SendAsync("GetPlayerCount", Users.Count);
            await Clients.All.SendAsync("GetBetsPlacedCount", betsCount);

            //needed by default, ne mano ismislas
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string username = Users.FirstOrDefault(u => u.Key == Context.ConnectionId).Value;
            await AddConnectionStatusMsg($"{username} left the game!");
            Users.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("GetPlayerCount", Users.Count);
            if (Users.Count < 1) TableHasPlayers = false;
        }

        public async Task AddConnectionStatusMsg(string message)
        {
            await Clients.All.SendAsync("GetMessage", message);
        }

        public async Task SendPlayerCount()
        {
            await Clients.All.SendAsync("GetPlayerCount", Users.Count);
        }

        public async Task PlaceABet()
        {
            await Clients.All.SendAsync("GetBetsPlacedCount", ++betsCount);
            if(betsCount >= Users.Count)
            {
                await RollANumber();
            }
        }

        public async Task RollANumber()
        {
            Random rand = new Random();
            int number = rand.Next(0, 36);
            await Clients.All.SendAsync("GetRolledNumber", ++number);
            betsCount = 0;
            await Clients.All.SendAsync("GetBetsPlacedCount", betsCount);
            await Clients.All.SendAsync("GetMessage", $"Rolled #{number}");
        }
    }
}
