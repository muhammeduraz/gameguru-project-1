using Zenject;
using UnityEngine;

namespace Assets.Scripts.GridModule
{
    public class GridModuleInstaller : MonoInstaller
    {
        #region Variables

        [SerializeField] private Grid _gridPrefab; 
        
        #endregion Variables
        
        #region Functions

        public override void InstallBindings()
        {
            Container.BindMemoryPool<Grid, GridPool>().FromComponentInNewPrefab(_gridPrefab);
            Container.BindInterfacesAndSelfTo<GridCreator>().AsSingle();
            Container.BindInterfacesAndSelfTo<GridManager>().AsSingle();
        }

        #endregion Functions
    }
}