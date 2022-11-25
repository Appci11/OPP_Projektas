namespace OPP_Projektas.Server.Models.Roulette
{
    public class RouletteUser
    {
        public string Username { get; set; } = string.Empty;
        public string GameId { get; set; } = string.Empty;
        public int BetAmmount { get; set; } = 0;
        public int BetType { get; set; } = 0; //1 onNumber; 2 onThird; 3 onColor
        // BetValue turetu but Bet, bet naisku kur pakeitus prades crashint...
        public int BetValue = 0;
        public string Bet { get; set; } = string.Empty;
        public int Winnings { get; set; } = 0;
        public RouletteUser(string username)
        {
            Username = username;
        }
        public RouletteUser(string id, string username)
        {
            GameId = id;
            Username = username;
        }
    }
}

