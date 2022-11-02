using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Server.Models.BlackJack;
using OPP_Projektas.Shared.Models.BlackJack;

namespace OPP_Projektas.Server.GameHubs;

public class BlackJackHub : Hub
{
    private BlackJackTable _blackJackTable = new();

    public async Task PlayerJoined(Guid userId, Guid tableId)
    {
        var player = new BlackJackPlayer {Balance = 500, Id = userId};
        await Clients.All.SendAsync("NewPlayerJoined", player);
        DoTheBadThing(player);
        //TODO TableService.AddPlayer(player, tableId)
    }

    public async Task Play(BlackJackPlayer player)
    {
        DoTheBadThing(player);
        await _blackJackTable.Play();
    }
    
    public async Task DrawCard(string playerId)
    {
        var card = _blackJackTable.Deck.Draw();
        await Task.Delay(1000);
        await Clients.All.SendAsync("CardDealt", playerId, card);
    }
    
    private void DoTheBadThing(BlackJackPlayer player)
    {
        _blackJackTable.Clients = Clients;
        _blackJackTable.Players.Add(player);
    }
}