﻿using Client.Code.Common.Data;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset.Data;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.ProgressService;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Common.Services.Startup;
using Client.Code.Game.Data;
using Client.Code.Game.Gameplay;
using Client.Code.Game.Gameplay.Car.Controllers;
using Client.Code.Game.Gameplay.Car.Factory;
using Client.Code.Game.Gameplay.GameplayCamera.Controllers;
using Client.Code.Game.Gameplay.GameplayCamera.Factory;
using Client.Code.Game.Gameplay.Player;
using Client.Code.Game.Gameplay.Player.Score;
using Client.Code.Game.Gameplay.Player.Time;
using Client.Code.Game.Infrastructure.States;
using Client.Code.Game.Services;
using Client.Code.Game.Services.Gameover;
using Client.Code.Game.Services.Pause;
using Client.Code.Game.UI.Factories;
using Client.Code.Game.UI.Presenters;
using UnityEngine;
using Zenject;

namespace Client.Code.Game.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSceneData _sceneData;

        public override void InstallBindings()
        {
            BindAssets();
            BindProgress();
            BindGameplay();
            BindGame();
            
            Container.Bind<GameSceneData>().FromInstance(_sceneData).AsSingle();
            Container.BindInterfacesTo<AutoStartupper<GameLoadState>>().AsSingle();
        }

        private void BindGame()
        {
            BindUI();
            BindPause();
            
            Container.Bind<GameFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverFactory>().AsSingle();
        }

        private void BindPause()
        {
            Container.Bind<PauseFactory>().AsSingle();
            Container.Bind<PauseService>().AsSingle();
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
            Container.BindInterfacesTo<AssetReceiversRegister<GameConfig>>().AsSingle();
            Container.BindInterfacesTo<AssetLoader<GameConfig>>().AsSingle().WithArguments(AssetLabelType.Game);
        }

        private void BindGameplay()
        {
            BindCar();
            BindPlayer();
            BindCamera();
            
            Container.Bind<GameplayFactory>().AsSingle();
        }

        private void BindCamera()
        {
            Container.BindInterfacesTo<CameraFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraInputController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraRotationController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraPositionController>().AsSingle();
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