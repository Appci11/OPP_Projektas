using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.Chat.Command;
using OPP_Projektas.Shared.Models.Chat;

namespace OPP_Projektas.Server.GameHubs
{
    public class ChatHub : Hub
    {
        static Dictionary<string, string> Users = new Dictionary<string, string>();
        static List<Message> Messages = new List<Message>();
        static ModifyMessagesList ModifyMessages = new ModifyMessagesList();
        static Receiver receiver = new Receiver(Messages);



        public override async Task OnConnectedAsync()
        {
            string username = Context.GetHttpContext().Request.Query["username"];
            Users.Add(Context.ConnectionId, username);
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
            Message msg = new Message(user, message);   //reiktu front'o callus keist...
            ModifyMessages.SetCommand(new ImplementedCommands(receiver, CommandsEnum.Add, msg));
            ModifyMessages.Invoke();
            await Clients.All.SendAsync("ReceiveMessages", Messages);
        }

        public async Task UndoAction()
        {
            ModifyMessages.UndoAction();
            await Clients.All.SendAsync("ReceiveMessages", Messages);
        }

        public async Task RedoAction()
        {
            ModifyMessages.RedoAction();
            await Clients.All.SendAsync("ReceiveMessages", Messages);
        }
    }
}
