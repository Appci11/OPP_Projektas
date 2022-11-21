namespace OPP_Projektas.Shared.Models.Roulette.Iterator
{
    class MyIterator : Iterator
    {
        private MyIterableCollection _collection;

        private int _position = -1;

        public MyIterator(MyIterableCollection collection)
        {
            this._collection = collection;
        }

        public object Current()
        {
            return this._collection.GetItem(_position);
        }

        public int Key()
        {
            return this._position;
        }

        public bool MoveNext()
        {
            int updatedPosition = this._position + 1;

            if (updatedPosition >= 0 && updatedPosition < this._collection.GetItemsCount())
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this._position = 0;
        }
    }
}
