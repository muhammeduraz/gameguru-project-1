using Zenject;

namespace Assets.Scripts.MatchModule
{
    public class MatchModuleSignalInstaller : Installer<MatchModuleSignalInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            Container.DeclareSignal<MatchOccuredSignal>();
        }

        #endregion Functions
    }
}