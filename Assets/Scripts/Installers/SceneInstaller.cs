using Zenject;
using Assets.Scripts.GridModule;
using Assets.Scripts.InputModule;
using Assets.Scripts.MatchModule;
using Assets.Scripts.TimerModule;

namespace Assets.Scripts.Installers
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            GridSignalInstaller.Install(Container);
            InputSignalInstaller.Install(Container);
            MatchSignalInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<Timer>().AsTransient();
            Container.BindInterfacesAndSelfTo<CustomInput>().AsSingle();

            Container.BindInterfacesAndSelfTo<GridSelector>().AsSingle();

            Container.BindInterfacesAndSelfTo<MatchOperation>().AsSingle();
        }

        #endregion Functions
    }
}