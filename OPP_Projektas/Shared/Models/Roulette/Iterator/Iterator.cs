using System.Collections;

namespace OPP_Projektas.Shared.Models.Roulette.Iterator
{
    public interface Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();
        public abstract int Key();
        public abstract object Current();
        public abstract bool MoveNext();
        public abstract void Reset();
    }
}
