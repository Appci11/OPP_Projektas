using OPP_Projektas.Shared.Models.Roulette.Iterator;

namespace OPP_Projektas.Server.Services.RouletteServices
{
    public class RouletteServices : IRouletteServices
    {
        List<string> GainsMessageLog { get; set; } = new List<string>();


        // realiai nebebus naudojama, bet uzkomentavus crashins,
        // tai palieku
        public void AddMessage(string msg)
        {
            GainsMessageLog.Add(msg);
            //Dabar paliekam pas save
            //Gal kada nors ir issiusim i serveri...
        }
    }
}
