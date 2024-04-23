using System;
using UnityEngine;
using Unity.Mathematics;

namespace Assets.Scripts.GridModule
{
    public class GridCreator : IDisposable
    {
        #region Variables

        private int _gridSize = 2;

        private Grid _cacheGrid;
        private GridPool _gridPool;

        private Grid[,] _gridArray;

        #endregion Variables

        #region Functions

        public GridCreator(GridPool gridPool)
        {
            _gridPool = gridPool;
        }

        public void Dispose()
        {
            _gridPool = null;
            _cacheGrid = null;
            _gridArray = null;
        }

        public Grid[,] CreateGrid(int gridSize)
        {
            DespawnActiveGrids();

            _gridSize = gridSize;
            _gridArray = new Grid[gridSize, gridSize];

            int gridMod = _gridSize % 2;
            float gridPositionOffset = ((1 - gridMod) * 0.5f);

            Vector2 topLeftGridPosition;
            topLeftGridPosition.x = 0f - (_gridSize / 2) + gridPositionOffset;
            topLeftGridPosition.y = (_gridSize / 2) - gridPositionOffset;

            Vector2 instantiatePosition = topLeftGridPosition;

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    _cacheGrid = _gridPool.Spawn();
                    _cacheGrid.Index = new int2(x, y);
                    _cacheGrid.transform.position = instantiatePosition;

                    _gridArray[x, y] = _cacheGrid;
                    instantiatePosition.x += 1f;
                }

                instantiatePosition.x = topLeftGridPosition.x;
                instantiatePosition.y -= 1f;
            }

            return _gridArray;
        }

        public void DespawnActiveGrids()
        {
            if (_gridArray == null) return;

            foreach (Grid grid in _gridArray)
            {
                _gridPool.Despawn(grid);
            }
        }

        #endregion Functions
    }
}