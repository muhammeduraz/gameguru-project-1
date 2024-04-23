using Zenject;

namespace Assets.Scripts.GridModule
{
    public class GridModuleSignalInstaller : Installer<GridModuleSignalInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<GridBuilSignal>();
            Container.DeclareSignal<SetupGridSignal>();
            Container.DeclareSignal<GridFlaggedSignal>();
        }
    }
}