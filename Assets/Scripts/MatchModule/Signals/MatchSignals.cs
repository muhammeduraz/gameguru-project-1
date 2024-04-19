namespace Assets.Scripts.MatchModule
{
    #region Signals

    public struct MatchOccuredSignal
    {
        private int _totalMatchCount;
        public int TotalMatchCount { get => _totalMatchCount; }

        public MatchOccuredSignal(int totalMatchCount)
        {
            _totalMatchCount = totalMatchCount;
        }
    }

    #endregion Signals
}