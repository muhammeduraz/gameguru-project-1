using Zenject;
using Assets.Scripts.GridModule;
using Assets.Scripts.MatchModule;

namespace Assets.Scripts.Installers
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            GridSignalInstaller.Install(Container);
            MatchSignalInstaller.Install(Container);
        }

        #endregion Functions
    }
}