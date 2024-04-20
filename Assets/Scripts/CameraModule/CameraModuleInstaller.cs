using Zenject;

namespace Assets.Scripts.CameraModule
{
    public class CameraModuleInstaller : MonoInstaller<CameraModuleInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CameraAdjuster>().AsSingle();
        }

        #endregion Functions
    }
}