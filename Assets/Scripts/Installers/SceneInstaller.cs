using Zenject;
using UnityEngine;
using Assets.Scripts.GridModule;
using Assets.Scripts.InputModule;
using Assets.Scripts.MatchModule;
using Grid = Assets.Scripts.GridModule.Grid;

namespace Assets.Scripts.Installers
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        #region Variables

        [SerializeField] private Grid _gridPrefab;

        #endregion Variables

        #region Functions

        public override void InstallBindings()
        {
            GridSignalInstaller.Install(Container);
            InputSignalInstaller.Install(Container);
            MatchSignalInstaller.Install(Container);

            Container.BindMemoryPool<Grid, GridPool>().FromComponentInNewPrefab(_gridPrefab).AsTransient();
            Container.BindInterfacesAndSelfTo<GridCreator>().AsSingle();
            Container.BindInterfacesAndSelfTo<GridManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<GridSelector>().AsSingle();

            Container.BindInterfacesAndSelfTo<MatchOperation>().AsSingle();
        }

        #endregion Functions
    }
}