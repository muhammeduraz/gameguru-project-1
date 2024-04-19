using Zenject;
using Assets.Scripts.TimerModule;

namespace Assets.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<Timer>().AsTransient();
        }

        #endregion Functions
    }
}