using Client.Code.Common.Data.Static.Configs.Gameplay;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Progress;
using Client.Code.Common.Services.Startup;
using Client.Code.Common.Services.StateMachine;
using Client.Code.Common.Services.StateMachine.Factory;
using Client.Code.Common.Services.Updater;
using Client.Code.Gameplay.Data;
using Client.Code.Gameplay.Game.Car;
using Client.Code.Gameplay.Game.Car.Controllers;
using Client.Code.Gameplay.Game.GameCamera;
using Client.Code.Gameplay.Game.Player;
using Client.Code.Gameplay.Game.Player.Score;
using Client.Code.Gameplay.Game.Player.Time;
using Client.Code.Gameplay.Infrastructure.States;
using Client.Code.Gameplay.UI;
using Client.Code.Gameplay.UI.GameOver;
using UnityEngine;
using Zenject;

namespace Client.Code.Gameplay.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameplaySceneData _sceneData;

        public override void InstallBindings()
        {
            BindStateMachine();
            Game();
            BindGameplay();
            BindAssets();

            Container.BindInterfacesTo<ProgressActorsRegister>().AsSingle();
            Container.BindInterfacesTo<Updater>().FromNewComponentOnNewGameObject().AsSingle();

            Container.Bind<GameplaySceneData>().FromInstance(_sceneData).AsSingle();
            Container.BindInterfacesTo<AutoStartupper<GameplayLoadState>>().AsSingle();
        }

        private void BindAssets()
        {
            Container.BindInterfacesTo<AssetReceiversRegister<GameplayConfig>>().AsSingle();
            Container.BindInterfacesTo<AssetLoader<GameplayConfig>>().AsSingle();
        }

        private void BindGameplay()
        {
            BindCar();
            BindPlayer();
            Container.BindInterfacesAndSelfTo<CameraFactory>().AsSingle();
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
            Container.BindInterfacesAndSelfTo<PlayerCoinsController>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}