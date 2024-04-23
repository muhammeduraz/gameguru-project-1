using TMPro;
using System;
using Zenject;
using UnityEngine;
using Assets.Scripts.MatchModule;

namespace Assets.Scripts.CanvasModule
{
    public class MatchCounterDisplay : MonoBehaviour, IInitializable, IDisposable
    {
        #region Variables

        private readonly string MatchCountText = "Match count: ";

        private SignalBus _signalBus;

        [Header("Components")]
        [SerializeField] private TextMeshProUGUI _matchCountText;

        #endregion Variables

        #region Functions

        [Inject]
        private void MatchCounterDisplayMonoConstructor(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<MatchOccuredSignal>(OnMatchSignalFired);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<MatchOccuredSignal>(OnMatchSignalFired);
        }

        private void OnMatchSignalFired(MatchOccuredSignal matchOccuredSignal)
        {
            SetMatchCountText(matchOccuredSignal.TotalMatchCount);
        }

        private void SetMatchCountText(int matchCount)
        {
            _matchCountText.text = MatchCountText + matchCount;
        }

        #endregion Functions
    }
}