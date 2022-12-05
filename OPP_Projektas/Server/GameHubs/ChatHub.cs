using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.Chat.Command;
using OPP_Projektas.Server.Models.Chat.FilterChain;
using OPP_Projektas.Server.Models.Chat.Memento;
using OPP_Projektas.Shared.Models.Chat;

namespace OPP_Projektas.Server.GameHubs
{
    public class ChatHub : Hub
    {
        static Dictionary<string, string> Users = new Dictionary<string, string>();
        static List<Message> Messages = new List<Message>();
        static ModifyMessagesList ModifyMessages = new ModifyMessagesList();
        static Receiver receiver = new Receiver(Messages);


        //static List<string> Messages = new List<string>();
        static Originator originator = new Originator(Messages);
        static Caretaker caretaker = new Caretaker(originator);

        static int n = 0;

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
            originator._messages.Add(msg);

            Console.WriteLine("Originator Messages:");
            foreach (var mmm in originator._messages)
            {
                Console.WriteLine(mmm.Username + " " + mmm.Msg);
            }

            var filterChain =
                new SwearWordHandler(new LithuanianSwearWordHandler(new PasswordAskerHandler(new AskHowHandler(null))));

            var filterResult = filterChain.Handle(message);
            if (!filterResult.passed)
            {
                var filterResponseMessage = new Message("Admin", filterResult.value);
                ModifyMessages.SetCommand(new ImplementedCommands(receiver, CommandsEnum.Add, filterResponseMessage));
                ModifyMessages.Invoke();
                await Clients.Caller.SendAsync("ReceiveMessages", Messages);
                return;
            }

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

        public async Task SaveMemento()
        {
            caretaker.Backup("Save1"); // galima ir pakeist save pavadinima netingint...
            Messages.Add(new Message("System", "Messages Saved"));
            await Clients.Client(Context.ConnectionId).SendAsync("GetMementosCount", 777);
            await Clients.All.SendAsync("ReceiveMessages", Messages);            
        }
        public async Task LoadMemento(int i)
        {
            caretaker.Load(i);
            Messages = originator._messages.ToList<Message>();
            receiver = new Receiver(Messages);
            await Clients.All.SendAsync("ReceiveMessages", Messages);
        }
    }
}
