namespace OPP_Projektas.Client.Models.Roulette
{
    public class ChipsAdapter : IChipsConverter
    {
        private readonly ChipsKeeper _chipsKeeper;

        public ChipsAdapter(ChipsKeeper chipsKeeper)
        {
            _chipsKeeper = chipsKeeper;
        }

        public int[] GetChipsMin()
        {
            int[] arr = { 0, 0, 0, 0, 0, 0 };
            int n = _chipsKeeper.Chips;

            arr[5] = n / 100;
            n = n % 100;
            arr[4] = n / 50;
            n = n % 50;
            arr[3] = n / 25;
            n = n % 25;
            arr[2] = n / 10;
            n = n % 10;
            arr[1] = n / 5;
            n = n % 5;
            arr[0] = n;

            return arr;
        }

        public int[] GetChips()
        {
            int[] arr = { 0, 0, 0, 0, 0, 0 };
            int n = _chipsKeeper.Chips;
            int half, add;

            half = n / 2;
            add = half / 100;
            arr[5] = add;
            n = n - (add * 100);
            half = n / 2;
            add = half / 50;
            arr[4] = add;
            n = n - (add * 50);
            half = n / 2;
            add = half / 25;
            arr[3] = add;
            n = n - (add * 25);
            half = n / 2;
            add = half / 10;
            arr[2] = add;
            n = n - (add * 10);
            half = n / 2;
            add = half / 5;
            arr[1] = add;
            n = n - (add * 5);
            arr[0] = n;

            return arr;
        }

        public int[] GetChipsMax()
        {
            int[] arr = { 0, 0, 0, 0, 0, 0 };
            int n = _chipsKeeper.Chips;
            arr[0] = n;

            return arr;
        }
    }
}
