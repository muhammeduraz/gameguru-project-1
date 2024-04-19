using TMPro;
using Zenject;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.GridModule;

namespace Assets.Scripts.CanvasModule
{
    public class SetupGridButton : MonoBehaviour, IInitializable
    {
        #region Variables

        private SignalBus _signalBus;

        [Header("Components")]
        [SerializeField] private Button _button;

        [Header("References")]
        [SerializeField] private TMP_InputField _inputField;

        #endregion Variables

        #region Functions

        [Inject]
        private void SetupGridButtonMonoConstructor(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            InitializeButton();
        }

        private void FireSetupGridSignal()
        {
            if (_inputField.text == string.Empty) return;
            _signalBus.Fire(new SetupGridSignal(int.Parse(_inputField.text)));
        }

        private void OnButtonClicked()
        {
            FireSetupGridSignal();
        }

        private void InitializeButton()
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(OnButtonClicked);
        }

        #endregion Functions
    }
}