namespace OPP_Projektas.Client.Models.Roulette
{
    public class NewChipsKeeper
    {
        public int[] Chips { get; set; } = { 0, 0, 0, 0, 0, 5 };
        public NewChipsKeeper()
        {

        }
        public NewChipsKeeper(int[] chips)
        {
            Chips = chips;
        }
    }
}
