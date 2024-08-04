using Client.Code.Common.Services.StateMachine;
using Client.Code.Common.Services.StateMachine.Factory;
using Zenject;

namespace Client.Code.Common.Infrastructure.Installers
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}