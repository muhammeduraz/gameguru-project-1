using Zenject;

namespace Assets.Scripts.InputModule
{
    public class InputSignalInstaller : Installer<InputSignalInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            Container.DeclareSignal<InputTapSignal>();
            Container.DeclareSignal<ChangeInputStateSignal>();
        }

        #endregion Functions
    }
}