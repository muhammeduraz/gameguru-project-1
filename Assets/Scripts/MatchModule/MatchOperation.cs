using System;
using Zenject;
using System.Linq;
using Assets.Scripts.GridModule;
using System.Collections.Generic;

namespace Assets.Scripts.MatchModule
{
    public class MatchOperation : IInitializable, IDisposable
    {
        #region Variables

        private int _matchCount;
        private const int CountForMatch = 3;

        private Grid _cacheGrid;

        private SignalBus _signalBus;
        private GridManager _gridManager;

        private List<Grid> _wbcGridList;
        private List<Grid> _tempGridList;
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

            _wbcGridList = new();
            _tempGridList = new();
            _cacheMatchedGridList = new();

            _signalBus.Subscribe<GridFlaggedSignal>(OnGridFlaggedSignalFired);
        }

        public void Dispose()
        {
            _cacheGrid = null;
            _gridManager = null;

            _wbcGridList = null;
            _tempGridList = null;
            _cacheMatchedGridList = null;

            _signalBus.Unsubscribe<GridFlaggedSignal>(OnGridFlaggedSignalFired);
            _signalBus = null;
        }

        private void OnGridFlaggedSignalFired(GridFlaggedSignal gridFlaggedSignal)
        {
            MatchIfPossible(gridFlaggedSignal.Grid);
        }

        private void MatchIfPossible(Grid grid)
        {
            bool matchDetected = DetectMatch(grid);
            if (!matchDetected)
            {
                OnMatchNotOccured();
                return;
            }

            OnMatchOccured();
        }

        private void OnMatchOccured()
        {
            _matchCount++;

            _cacheMatchedGridList.ForEach(grid => grid.SetAsUnflagged());
            _cacheMatchedGridList.Clear();

            _signalBus.Fire(new MatchOccuredSignal(_matchCount));
        }

        private void OnMatchNotOccured()
        {
            _cacheMatchedGridList.Clear();
        }

        private bool DetectMatch(Grid grid)
        {
            _cacheMatchedGridList.Clear();
            _cacheMatchedGridList.Add(grid);

            _wbcGridList.Clear();
            _tempGridList = _gridManager.GetFlaggedNeighbours(grid);
            _tempGridList.ForEach(grid => _wbcGridList.Add(grid));

            while (_wbcGridList.Count > 0)
            {
                _cacheGrid = _wbcGridList.FirstOrDefault();
                _wbcGridList.Remove(_cacheGrid);

                if (_cacheMatchedGridList.Contains(_cacheGrid)) continue;
                _cacheMatchedGridList.Add(_cacheGrid);

                _tempGridList = _gridManager.GetFlaggedNeighbours(_cacheGrid);
                foreach (Grid loopGrid in _tempGridList)
                {
                    if (_wbcGridList.Contains(loopGrid) || _cacheMatchedGridList.Contains(loopGrid)) continue;
                    _wbcGridList.Add(loopGrid);
                }
            }

            _wbcGridList.Clear();
            _tempGridList.Clear();

            if (_cacheMatchedGridList.Count < CountForMatch) return false;
            return true;
        }

        #endregion Functions
    }
}