using System;
using Zenject;
using UnityEngine;
using Assets.Scripts.InputModule;

namespace Assets.Scripts.GridModule
{
    public class GridSelector : IInitializable, IDisposable
    {
        #region Variables

        private SignalBus _signalBus;

        private Camera _camera;
        private Grid _cacheGrid;
        private GridFlaggedSignal _cacheGridFlaggedSignal;

        private Ray _ray;
        private RaycastHit[] _hitArray;

        #endregion Variables

        #region Functions

        [Inject]
        public GridSelector(SignalBus signalBus)
        {
            _ray = new();
            _camera = Camera.main;

            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _hitArray = new RaycastHit[1];
            _cacheGridFlaggedSignal = new GridFlaggedSignal();
            _signalBus.Subscribe<InputTapSignal>(OnInputTapSignalFired);
        }

        public void Dispose()
        {
            _camera = null;
            _hitArray = null;
            _cacheGrid = null;
            _cacheGridFlaggedSignal.Grid = null;

            _signalBus.Unsubscribe<InputTapSignal>(OnInputTapSignalFired);
            _signalBus = null;
        }

        private void OnInputTapSignalFired(InputTapSignal inputTapSignal)
        {
            TryToFlagGrid(inputTapSignal.MousePosition);
        }

        private void TryToFlagGrid(Vector3 mousePosition)
        {
            bool gridFetched = FetchGrid(mousePosition);
            if (gridFetched == false || _cacheGrid.Flagged) return;

            _cacheGrid.SetAsFlagged();

            _cacheGridFlaggedSignal.Grid = _cacheGrid;
            _signalBus.Fire(_cacheGridFlaggedSignal);
        }

        private bool FetchGrid(Vector3 mousePosition)
        {
            _ray = _camera.ScreenPointToRay(mousePosition);
            int count = Physics.RaycastNonAlloc(_ray, _hitArray);
            if (count < 1) return false;

            foreach (RaycastHit hit in _hitArray)
            {
                if (hit.collider == null) continue;

                bool gotComponent = hit.collider.TryGetComponent(out _cacheGrid);
                if (gotComponent == false) continue;

                break;
            }

            return true;
        }

        #endregion Functions
    }
}