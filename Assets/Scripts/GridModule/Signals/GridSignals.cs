namespace Assets.Scripts.GridModule
{
    #region Signals

    public struct SetupGridSignal
    {
        private int _size;
        public int Size { get => _size; }

        public SetupGridSignal(int size)
        {
            _size = size;
        }
    }

    public struct GridFlaggedSignal
    {
        private Grid _grid;
        public Grid Grid { get => _grid; set => _grid = value; }

        public GridFlaggedSignal(Grid grid)
        {
            _grid = grid;
        }
    }

    #endregion Signals
}