using System;
using Zenject;
using Assets.Scripts.GridModule;
using System.Collections.Generic;

namespace Assets.Scripts.MatchModule
{
    public class MatchOperation : IInitializable, IDisposable
    {
        #region Variables

        private int _matchCount;

        private SignalBus _signalBus;
        private GridManager _gridManager;

        private List<Grid> _cacheMatchedGridList;

        #endregion Variables

        #region Functions

        public MatchOperation(SignalBus signalBus, GridManager gridManager)
        {
            _signalBus = signalBus;
            _gridManager = gridManager;
        }

        public void Initialize()
        {
            _matchCount = 0;
            _cacheMatchedGridList = new();
            _signalBus.Subscribe<GridFlaggedSignal>(OnGridFlaggedSignalFired);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<GridFlaggedSignal>(OnGridFlaggedSignalFired);
            _signalBus = null;
        }

        private void OnGridFlaggedSignalFired(GridFlaggedSignal gridFlaggedSignal)
        {
            MatchSequence(gridFlaggedSignal.Grid);
        }

        private void OnMatchOccured()
        {
            _matchCount++;
            _cacheMatchedGridList.ForEach(grid => grid.SetAsUnflagged());

            _signalBus.Fire(new MatchOccuredSignal(_matchCount));
        }

        private void OnMatchNotOccured()
        {

        }

        private bool DetectMatch(Grid grid)
        {
            _cacheMatchedGridList.Clear();

            return true;
        }

        private void MatchSequence(Grid grid)
        {
            bool matchDetected = DetectMatch(grid);
            matchDetected = true;
            if (!matchDetected)
            {
                OnMatchNotOccured();
                return;
            }

            OnMatchOccured();
        }

        #endregion Functions
    }
}