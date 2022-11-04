namespace OPP_Projektas.Server.Services.RouletteServices
{
    public class RouletteServices : IRouletteServices
    {
        List<string> MessageLog { get; set; } = new List<string>();
        public void SendLogToServer(string msg)
        {
            MessageLog.Add(msg);
            //Dabar paliekam pas save
            //Gal kada nors ir issiusim i serveri...
        }
    }
}
