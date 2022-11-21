using System.Collections;

namespace OPP_Projektas.Shared.Models.Roulette.Iterator
{
    public interface IterableCollection : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}
