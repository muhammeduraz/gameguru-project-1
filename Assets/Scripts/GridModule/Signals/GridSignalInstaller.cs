using Zenject;

namespace Assets.Scripts.GridModule
{
    public class GridSignalInstaller : Installer<GridSignalInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SetupGridSignal>();
        }
    }
}