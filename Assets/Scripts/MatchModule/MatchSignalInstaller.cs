using Zenject;

namespace Assets.Scripts.MatchModule
{
    public class MatchSignalInstaller : Installer<MatchSignalInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            Container.DeclareSignal<MatchOccuredSignal>();
        }

        #endregion Functions
    }
}