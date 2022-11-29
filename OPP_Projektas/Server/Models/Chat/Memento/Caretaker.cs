namespace OPP_Projektas.Server.Models.Chat.Memento
{
    class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();

        private Originator _originator = null;

        public Caretaker(Originator originator)
        {
            this._originator = originator;
        }

        public void Backup(string saveName)
        {
            this._mementos.Add(this._originator.Save(saveName));
        }

        public void Load(int saveNr)
        {
            if (this._mementos.Count == 0)
            {
                return;
            }

            var memento = _mementos[saveNr];

            try
            {
                this._originator.Restore(memento);
            }
            catch (Exception)
            {
                this.Load(saveNr);
            }
        }

        public int GetSavesCount()
        {
            return _mementos.Count;
        }
    }
}
