using Zenject;
using Assets.Scripts.GridModule;

namespace Assets.Scripts.Installers
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            GridSignalInstaller.Install(Container);
        }

        #endregion Functions
    }
}