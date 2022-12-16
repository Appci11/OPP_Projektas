using Microsoft.AspNetCore.SignalR;
using OPP_Projektas.Client.Models.BlackJack;
using OPP_Projektas.Server.Services;

namespace OPP_Projektas.Server.GameHubs;

public class BlackJackHub : Hub
{
    private readonly BlackJackTableServices _blackJackTableServices;

    public BlackJackHub(BlackJackTableServices blackJackTableServices)
    {
        _blackJackTableServices = blackJackTableServices;
    }

    public async Task CreateNewTable(BlackJackDealer dealer)
    {
        var table = _blackJackTableServices.CreateTable(dealer);
        await Clients.All.SendAsync("TableCreated", table);
    }
    
    public async Task PlayerJoined(BlackJackPlayer player)
    {
        _blackJackTableServices.Clients = Clients;
        await Clients.All.SendAsync("NewPlayerJoined", player);
        await _blackJackTableServices.AddPlayer(player);
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