using System;
using Zenject;
using UnityEngine;
using Assets.Scripts.TimerModule;

namespace Assets.Scripts.InputModule
{
    public class CustomInput : IInitializable, ITickable, IDisposable
    {
        #region Variables

        private bool _isActive;

        private float _tapTimeThreshold = 0.2f;
        private float _tapDistanceThreshold = 5f;

        private Vector3 _mouseDownPosition;
        
        private Timer _timer;
        private SignalBus _signalBus;

        #endregion Variables

        #region Properties

        private Vector3 MousePosition { get => Input.mousePosition; }

        #endregion Properties

        #region Functions

        public CustomInput(Timer timer, SignalBus signalBus)
        {
            _timer = timer;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _isActive = true;
        }

        public void Tick()
        {
            if (!_isActive) return;

            if (Input.GetMouseButtonDown(0))
            {
                OnButtonDown();
            }
            else if (Input.GetMouseButton(0))
            {
                OnButton();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                OnButtonUp();
            }
        }

        public void Dispose()
        {
            _timer = null;
        }

        private void OnButtonDown()
        {
            _mouseDownPosition = MousePosition;
            _timer.SetTimer(_tapTimeThreshold);
        }

        private void OnButton()
        {
            _timer.Update();
        }

        private void OnButtonUp()
        {
            float distance = Vector3.Distance(_mouseDownPosition, MousePosition);

            if (!_timer.IsTimeUp && distance < _tapDistanceThreshold)
            {
                _signalBus.Fire(new InputTapSignal(MousePosition));
            }

            _timer.Reset();
        }

        #endregion Functions
    }
}