namespace OPP_Projektas.Client.Models.Roulette
{
    public class ChipsKeeper
    {
        public int Chips { get; set; } = 500;   //netikrinam negative...

        public ChipsKeeper() { }
        public ChipsKeeper(int chips) => Chips = chips;

        public int GetChips()
        {
            return Chips;
        }

        public void AddChips(int ammount)
        {
            Chips += ammount;
        }
        public void RemoveChips(int ammount)
        {
            Chips -= ammount;
        }
    }
}
