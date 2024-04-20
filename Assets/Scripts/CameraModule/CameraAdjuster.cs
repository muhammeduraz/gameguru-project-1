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
            _signalBus.Subscribe<SetupGridSignal>(OnSetupGridSignalFired);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SetupGridSignal>(OnSetupGridSignalFired);
            _signalBus = null;
        }

        private void OnSetupGridSignalFired(SetupGridSignal setupGridSignal)
        {
            _mainCamera.orthographicSize = setupGridSignal.Size;
        }

        #endregion Functions
    }
}