namespace OPP_Projektas.Server.Models.Roulette
{
    public class RouletteMessagesCreator
    {
        List<string>? Messages;

        public List<string> FormMessages(List<RouletteUser> users)
        {
            Messages = new List<string>();
            int bigWin = 0;
            int betAmm = 0;
            foreach(RouletteUser user in users)
            {
                if(user.Winnings > bigWin)
                {
                    bigWin = user.Winnings;
                    betAmm = user.BetAmmount;
                }
            }
            Messages.Add($"Greatest winning: {bigWin - betAmm}");
            return Messages;
        }

        void AddPersonalizedMessages(List<RouletteUser> users)
        {
            //To be added maybe someday...
            //Needs a way to save id's.
        }
    }
}
