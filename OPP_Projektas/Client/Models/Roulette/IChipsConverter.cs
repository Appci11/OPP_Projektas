namespace OPP_Projektas.Client.Models.Roulette
{
    public interface IChipsConverter
    {
        public int[] GetChipsMin();
        public int[] GetChips();
        public int[] GetChipsMax();
    }
}
