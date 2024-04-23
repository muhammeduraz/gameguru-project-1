using Zenject;
using UnityEngine;

namespace Assets.Scripts.CanvasModule
{
    public class CanvasModuleInstaller : MonoInstaller
    {
        #region Variables

        [Header("References")]
        [SerializeField] private SetupGridButton _setupGridButton;
        [SerializeField] private MatchCounterDisplay _matchCountDisplay;

        #endregion Variables
        
        #region Functions
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SetupGridButton>().FromInstance(_setupGridButton).AsSingle();
            Container.BindInterfacesTo<MatchCounterDisplay>().FromInstance(_matchCountDisplay).AsSingle();
        }

        #endregion Functions
    }
}