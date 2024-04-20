using System;
using Zenject;
using Unity.Mathematics;
using System.Collections.Generic;

namespace Assets.Scripts.GridModule
{
    public class GridManager : IInitializable, IDisposable
    {
        #region Variables

        private int _gridSize;

        private SignalBus _signalBus;

        private Grid[,] _gridArray;
        private GridCreator _gridCreator;

        private List<Grid> _cacheGridList;

        private List<int2> _indexOffsetList = new List<int2>
        {
            new int2(-1, 0), // Up
            new int2(+1, 0), // Down
            new int2(0, +1), // Right
            new int2(0, -1) // Left
        };

        #endregion Variables
        
        #region Properties

        public Grid[,] GridArray { get => _gridArray; }

        #endregion Properties

        #region Functions

        public GridManager(GridCreator gridCreator, SignalBus signalBus)
        {
            _signalBus = signalBus;
            _gridCreator = gridCreator;
        }

        public void Initialize()
        {
            _cacheGridList = new List<Grid>();
            _signalBus.Subscribe<SetupGridSignal>(OnSetupGridSignalFired);

            _gridSize = 2;
            SetupGrid(2);
        }

        public void Dispose()
        {
            _gridArray = null;
            _gridCreator = null;

            _signalBus.Unsubscribe<SetupGridSignal>(OnSetupGridSignalFired);
            _signalBus = null;
        }

        private void SetupGrid(int size)
        {
            _gridSize = size;

            ResetFlagStatusOfAllGrids();
            _gridArray = _gridCreator.CreateGrid(size);

            _signalBus.Fire(new GridBuilSignal(size));
        }

        private void ResetFlagStatusOfAllGrids()
        {
            if (_gridArray == null || _gridArray.Length < 1) return;
            foreach (Grid grid in _gridArray) grid.SetAsUnflagged();
        }

        private void OnSetupGridSignalFired(SetupGridSignal setupGridSignal)
        {
            SetupGrid(setupGridSignal.Size);
        }

        public List<Grid> GetFlaggedNeighbours(Grid grid)
        {
            _cacheGridList.Clear();

            foreach (int2 indexOffset in _indexOffsetList)
            {
                if (IsGridAvailable(grid.Index, indexOffset))
                    _cacheGridList.Add(_gridArray[grid.Index.x + indexOffset.x, grid.Index.y + indexOffset.y]);
            }

            return _cacheGridList;
        }

        private bool IsGridAvailable(int2 gridIndex, int2 indexOffset)
        {
            if (_gridArray == null) return false;

            int2 newPos = gridIndex + indexOffset;
            if (newPos.x < 0 || newPos.x >= _gridSize) return false;
            if (newPos.y < 0 || newPos.y >= _gridSize) return false;
            if (_gridArray[newPos.x, newPos.y] == null || !_gridArray[newPos.x, newPos.y].Flagged) return false;

            return true;
        }

        #endregion Functions
    }
}