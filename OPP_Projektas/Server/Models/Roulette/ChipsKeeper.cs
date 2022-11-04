namespace OPP_Projektas.Server.Models.Roulette
{
    public class ChipsKeeper
    {
        public int Chips { get; set; } = 1000;
        private List<int> Record = new List<int>();

        public void AddChips(int number)
        {
            Chips += number;
            AddToRecord(number);
        }

        private void AddToRecord(int number)
        {
            Record.Add(number);
        }
    }
}
