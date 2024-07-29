using Client.Code.Infrastructure.States;
using Client.Code.Services.Startup.Delayed;
using Client.Code.Services.StateMachine;
using Client.Code.Services.StateMachine.Factory;
using Zenject;

namespace Client.Code.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            Container.BindInterfacesTo<DelayedStartupper<GameplayState>>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}