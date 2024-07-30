using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Car;
using Client.Code.Gameplay.Wheel;
using Client.Code.Infrastructure.States;
using Client.Code.Services.Startup.Delayed;
using Client.Code.Services.StateMachine;
using Client.Code.Services.StateMachine.Factory;
using UnityEngine;
using Zenject;

namespace Client.Code.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameplaySceneData _sceneData;
        [SerializeField] private GameplayConfig _config;

        public override void InstallBindings()
        {
            BindStateMachine();
            BindCar();
            
            Container.BindInterfacesTo<AssetProviderGameplayConfig>().AsSingle().WithArguments(_config);
            Container.Bind<GameplaySceneData>().FromInstance(_sceneData).AsSingle();
            Container.BindInterfacesTo<DelayedStartupper<GameplayState>>().AsSingle();
        }

        private void BindCar()
        {
            Container.Bind<CarFactory>().AsSingle();
            Container.Bind<CarMoveController>().AsSingle();
            Container.Bind<CarInputController>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}