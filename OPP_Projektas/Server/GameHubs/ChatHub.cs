using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Shared.Models.Chat;

namespace OPP_Projektas.Server.GameHubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> Users = new Dictionary<string, string>();
        private static List<Message> Messages = new List<Message>();

        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            Users.Add(Context.ConnectionId, username);
            //await AddMessageToChat(string.Empty, "User connected!");
            await AddMessageToChat(username, "connected!");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string username = Users.FirstOrDefault(u => u.Key == Context.ConnectionId).Value;
            await AddMessageToChat(username, "left!");
        }

        public async Task AddMessageToChat(string user, string message)
        {
            Messages.Add(new Message(user, message));
            await Clients.All.SendAsync("ReceiveMessages", Messages);
        }
    }
}
