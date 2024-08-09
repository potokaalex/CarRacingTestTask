using Client.Code.Common.Data.Configs;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.Asset.Data;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.ProgressService;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Common.Services.Startup;
using Client.Code.Gameplay.Data;
using Client.Code.Gameplay.Data.Static.Configs;
using Client.Code.Gameplay.Game.Car.Controllers;
using Client.Code.Gameplay.Game.Car.Factory;
using Client.Code.Gameplay.Game.GameCamera.Factory;
using Client.Code.Gameplay.Game.Player;
using Client.Code.Gameplay.Game.Player.Score;
using Client.Code.Gameplay.Game.Player.Time;
using Client.Code.Gameplay.Infrastructure.States;
using Client.Code.Gameplay.UI.Factories;
using Client.Code.Gameplay.UI.Presenters;
using UnityEngine;
using Zenject;

namespace Client.Code.Gameplay.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameplaySceneData _sceneData;

        public override void InstallBindings()
        {
            BindUI();
            BindGame();
            BindAssets();
            BindProgress();

            Container.Bind<GameplaySceneData>().FromInstance(_sceneData).AsSingle();
            Container.BindInterfacesTo<AutoStartupper<GameplayLoadState>>().AsSingle();
        }

        private void BindProgress()
        {
            Container.BindInterfacesTo<ProgressSaver<PlayerProgress>>().AsSingle();
            Container.BindInterfacesTo<ProgressLoader<PlayerProgress>>().AsSingle();
            
            Container.BindInterfacesTo<ProgressActorsRegister<PlayerProgress>>().AsSingle();
        }

        private void BindAssets()
        {
            Container.BindInterfacesTo<AssetReceiversRegister<ProjectConfig>>().AsSingle();
            Container.BindInterfacesTo<AssetReceiversRegister<GameplayConfig>>().AsSingle();
            Container.BindInterfacesTo<AssetLoader<GameplayConfig>>().AsSingle().WithArguments(AssetLabelType.Gameplay);
        }

        private void BindGame()
        {
            BindCar();
            BindPlayer();
            Container.BindInterfacesTo<CameraFactory>().AsSingle();
        }

        private void BindUI()
        {
            Container.BindInterfacesAndSelfTo<GameUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverScreenFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameOverPresenter>().AsSingle();
            Container.BindInterfacesTo<GamePresenter>().AsSingle();
        }

        private void BindCar()
        {
            Container.BindInterfacesTo<CarFactory>().AsSingle();
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
    }
}