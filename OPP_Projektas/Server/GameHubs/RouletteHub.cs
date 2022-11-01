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
        int PlaceBetsTimer = 10;

        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            Users.Add(Context.ConnectionId, username);
            //await AddConnectionStatusMsg(string.Empty, "User connected!");
            await AddConnectionStatusMsg($"{username} joined the game!");
            if (!TableHasPlayers)
            {
                TableHasPlayers = true;
                await RunPlaceBetsTimer();
            }

            //needed by default, ne mano ismislas
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string username = Users.FirstOrDefault(u => u.Key == Context.ConnectionId).Value;
            await AddConnectionStatusMsg($"{username} left the game!");
            Users.Remove(Context.ConnectionId);
            if (Users.Count < 1) TableHasPlayers = false;
        }

        public async Task AddConnectionStatusMsg(string message)
        {
            await Clients.All.SendAsync("GetThatMessage", message);
        }

        public async Task RunPlaceBetsTimer()
        {
            while (TableHasPlayers)
            {
                while (PlaceBetsTimer > 0)
                {
                    await SendPlaceBetsTime(PlaceBetsTimer);
                    PlaceBetsTimer--;
                    Thread.Sleep(1000);
                }
                PlaceBetsTimer = 10;
            }
        }

        public async Task SendPlaceBetsTime(int time)
        {
            await Clients.All.SendAsync("GetPlaceBetsTime", time);
        }
    }
}
