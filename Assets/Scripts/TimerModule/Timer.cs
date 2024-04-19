using System;
using UnityEngine;

namespace Assets.Scripts.TimerModule
{
    public class Timer : IDisposable
    {
        #region Variables

        private float _time;
        private float _timer;

        #endregion Variables

        #region Properties

        public float TimerValue { get => _timer; }
        public bool IsTimeUp { get => _timer < 0f; }

        #endregion Properties

        #region Functions

        public Timer()
        {

        }

        public void Dispose()
        {
            
        }

        public void SetTimer(float time)
        {
            _time = time;
            _timer = 0;
        }

        public void Reset()
        {
            _time = 0f;
            _timer = 0f;
        }

        public void Update()
        {
            if (_timer < 0f) return;

            _timer -= Time.deltaTime;
        }

        #endregion Functions

    }
}