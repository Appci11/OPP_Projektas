using System.Collections;

namespace OPP_Projektas.Shared.Models.Roulette.Iterator
{
    public class MyIterableCollection : IterableCollection
    {
        List<string> _collection = new List<string>();
        SortedSet<string> _uniqueUsers { get; set; } = new SortedSet<string>();
        // 0 - chip balance, 1 - current player count
        string[] _casinoStats = new string[2] { "Not Set", "Not Set" };
        int _count = 0;
        int nLog = 0;
        int nUsers = 0;

        public int GetItemsCount()
        {
            return _count + 2;
        }
        public List<string> getItems()
        {
            return _collection;
        }
        public string GetItem(int position)
        {
            // array dalis
            if (position - nLog - nUsers >= 0)
            {
                if (position - nLog - nUsers == 0)
                    return _casinoStats[0];
                return _casinoStats[1];
            }

            if (_count >= position + 2)
            {
                return _collection[position];
            }
            int n = _count - position;
            string eil = _uniqueUsers.ElementAt(n - 1);
            return eil;
        }

        public void AddToLog(string item)
        {
            this._collection.Add(item);
            nLog++;
            _count++;
        }
        public void AddUser(string item)
        {
            bool added = _uniqueUsers.Add(item);
            if (added)
            {
                nUsers++;
                _count++;
            }
        }
        /// <summary>
        /// Sets stats of current roulette play session
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="userCount"></param>
        public void SetStats(int balance, int userCount)
        {
            _casinoStats[0] = "Current balance: " + balance.ToString();
            _casinoStats[1] = "Current user count: " + userCount.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return new MyIterator(this);
        }
    }
}
