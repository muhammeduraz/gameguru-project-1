using System;
using Zenject;
using UnityEngine;
using Assets.Scripts.GridModule;

namespace Assets.Scripts.CameraModule
{
    public class CameraAdjuster : IInitializable, IDisposable
    {
        #region Variables

        private Camera _mainCamera;
        private SignalBus _signalBus;

        #endregion Variables

        #region Functions

        public CameraAdjuster(SignalBus signalBus, [Inject(Id = "MainCamera")] Camera mainCamera)
        {
            _signalBus = signalBus;
            _mainCamera = mainCamera;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<GridBuilSignal>(OnGridBuilSignalFired);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<GridBuilSignal>(OnGridBuilSignalFired);
            _signalBus = null;
        }

        private void OnGridBuilSignalFired(GridBuilSignal gridBuilSignal)
        {
            float aspectRatio = (float)Screen.height / Screen.width;
            float newOrthoSize = gridBuilSignal.Size * aspectRatio * 0.5f;

            _mainCamera.orthographicSize = newOrthoSize;
        }

        #endregion Functions
    }
}