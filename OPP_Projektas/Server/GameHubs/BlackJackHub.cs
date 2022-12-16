using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Services;
using OPP_Projektas.Shared.Models.BlackJack;

namespace OPP_Projektas.Server.GameHubs;

public class BlackJackHub : Hub
{
    private readonly BlackJackTableServices _blackJackTableServices;

    public BlackJackHub(BlackJackTableServices blackJackTableServices)
    {
        _blackJackTableServices = blackJackTableServices;
    }

    public async Task PlayerJoined(Guid userId, Guid tableId)
    {
        _blackJackTableServices.Clients = Clients;
        var player = new BlackJackPlayer()
        {
            Balance = 500, Id = userId,
            TableJoinedGuid = tableId
        };
        await Clients.All.SendAsync("NewPlayerJoined", player);
        await _blackJackTableServices.AddPlayer(player, tableId);
    }

    public async Task PlayerBet(Guid playerId, int betSize)
    {
        await _blackJackTableServices.PlayerBet(playerId, betSize);
    }
    
    public async Task Play(BlackJackPlayer player)
    {
        await _blackJackTableServices.Play();
    }
    
    public async Task DrawCard(string playerId)
    {
        // var card = _blackJackTable.Deck.Draw();
        // await Task.Delay(1000);
        // await Clients.All.SendAsync("CardDealt", playerId, card);
    }
}