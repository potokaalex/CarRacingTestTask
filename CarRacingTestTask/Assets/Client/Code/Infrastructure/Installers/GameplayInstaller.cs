using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Car;
using Client.Code.Gameplay.Car.Controllers;
using Client.Code.Gameplay.Game;
using Client.Code.Gameplay.Game.Over;
using Client.Code.Gameplay.GameplayCamera;
using Client.Code.Gameplay.Player;
using Client.Code.Gameplay.Player.Score;
using Client.Code.Gameplay.Player.Time;
using Client.Code.Infrastructure.States.Gameplay;
using Client.Code.Services.Asset;
using Client.Code.Services.Asset.Receiver;
using Client.Code.Services.Startup.Auto;
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

        public override void InstallBindings()
        {
            BindStateMachine();
            Game();
            BindCar();
            BindPlayer();

            Container.BindInterfacesAndSelfTo<CameraFactory>().AsSingle();
            Container.BindInterfacesTo<AssetReceiversRegister<GameplayConfig>>().AsSingle();
            Container.Bind<GameplaySceneData>().FromInstance(_sceneData).AsSingle();
            Container.BindInterfacesTo<DelayedStartupper<GameplayState>>().AsSingle();
        }

        private void Game()
        {
            Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverScreenFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverPresenter>().AsSingle();
            Container.BindInterfacesTo<GamePresenter>().AsSingle();
        }

        private void BindCar()
        {
            Container.BindInterfacesAndSelfTo<CarFactory>().AsSingle();
            Container.Bind<CarDriftChecker>().AsSingle();
            Container.Bind<CarController>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
            Container.Bind<PlayerTimeController>().AsSingle();
            Container.Bind<PlayerScoreController>().AsSingle();
            Container.Bind<PlayerCoinsController>().AsSingle();
        }
        
        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}