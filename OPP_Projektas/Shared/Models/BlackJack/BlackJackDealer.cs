using Microsoft.AspNetCore.SignalR.Client;

namespace OPP_Projektas.Client.Models.BlackJack;

public class BlackJackDealer : Player
{
    public override void ChooseAction()
    {
        throw new NotImplementedException();
    }

    public BlackJackDealer(HubConnection hubConnection) : base(hubConnection)
    {
    }
}