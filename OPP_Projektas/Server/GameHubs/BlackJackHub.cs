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
        _blackJackTableServices.Clients = Clients;
    }

    public async Task CreateNewTable(BlackJackDealer dealer)
    {
        System.Console.WriteLine("Creating new table");
        _blackJackTableServices.Clients = Clients;
        var table = _blackJackTableServices.CreateTable(dealer);
        await Clients.All.SendAsync("TableCreated", table);
    }
    
    public async Task PlayerJoined(BlackJackPlayer player)
    {
        _blackJackTableServices.Clients = Clients;
        Console.WriteLine("Player joined");
        await _blackJackTableServices.AddPlayer(player);
        await Clients.All.SendAsync("NewPlayerJoined", player);
    }

    public async Task PlayerBet(BlackJackPlayer player, int betSize)
    {
        System.Console.WriteLine("Player betting");
        _blackJackTableServices.Clients = Clients;
        await _blackJackTableServices.PlayerBet(player, betSize);
    }
    
    public async Task Play()
    {
        _blackJackTableServices.Clients = Clients;
        await _blackJackTableServices.Play();
    }
    
    public async Task DrawCard(Guid playerId)
    {
        _blackJackTableServices.Clients = Clients;
        var card = _blackJackTableServices.DrawCard();
        await Task.Delay(1000);
        await Clients.All.SendAsync("CardDealt", playerId, card);
    }
}