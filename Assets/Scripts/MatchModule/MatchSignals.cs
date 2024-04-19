namespace Assets.Scripts.MatchModule
{
    #region Signals

    public struct MatchOccuredSignal
    {
        private int _matchCount;
        public int MatchCount { get => _matchCount; }

        public MatchOccuredSignal(int matchCount)
        {
            _matchCount = matchCount;
        }
    }

    #endregion Signals
}