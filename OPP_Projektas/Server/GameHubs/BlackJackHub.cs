using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Shared.Models.BlackJack;

namespace OPP_Projektas.Server.GameHubs;

public class BlackJackHub : Hub
{
    public async Task PlayerJoined(Guid userId, Guid tableId)
    {
        var player = new BlackJackPlayer {Balance = 500, Id = userId};
        await Clients.All.SendAsync("NewPlayerJoined", player);
        //TODO TableService.AddPlayer(player, tableId)
    }

}