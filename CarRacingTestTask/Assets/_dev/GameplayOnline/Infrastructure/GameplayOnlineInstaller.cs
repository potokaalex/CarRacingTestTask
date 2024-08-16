using Client._dev.GameplayOnline.Data;
using Client._dev.GameplayOnline.Data.Static.Configs;
using Client._dev.GameplayOnline.Game;
using Client._dev.GameplayOnline.Game.Car;
using Client._dev.GameplayOnline.Game.GameCamera;
using Client._dev.GameplayOnline.Infrastructure.States;
using Client._dev.GameplayOnline.UI;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.Asset.Data;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Network.Events;
using Client.Code.Common.Services.ProgressService;
using Client.Code.Common.Services.Startup;
using Client.Code.Game.Gameplay.Car.Controllers;
using Client.Code.Game.UI.Presenters;
using UnityEngine;
using Zenject;

namespace Client._dev.GameplayOnline.Infrastructure
{
    public class GameplayOnlineInstaller : MonoInstaller
    {
        [SerializeField] private GameplayOnlineSceneData _sceneData;

        public override void InstallBindings()
        {
            BindAssets();
            BindUI();
            BindGameplay();

            Container.BindInterfacesTo<ProgressActorsRegister<PlayerProgress>>().AsSingle();
            Container.BindInterfacesTo<NetworkEventReceiversRegister>().AsSingle();
            Container.Bind<GameplayOnlineSceneData>().FromInstance(_sceneData).AsSingle();
            Container.BindInterfacesTo<AutoStartupper<GameplayOnlineLoadState>>().AsSingle();
        }

        private void BindGameplay()
        {
            BindCar();
            Container.BindInterfacesTo<CameraFactoryOnline>().AsSingle();
            Container.Bind<GameStartCheckerOnline>().AsSingle();
        }

        private void BindCar()
        {
            Container.BindInterfacesTo<CarFactoryOnline>().AsSingle();
            Container.Bind<CarController>().AsSingle();
        }

        private void BindUI()
        {
            Container.BindInterfacesAndSelfTo<GameUIFactoryOnline>().AsSingle();
            Container.BindInterfacesTo<GamePresenter>().AsSingle();
        }

        private void BindAssets()
        {
            Container.BindInterfacesTo<AssetReceiversRegister<GameplayOnlineConfig>>().AsSingle();
            Container.BindInterfacesTo<AssetLoader<GameplayOnlineConfig>>().AsSingle().WithArguments(AssetLabelType.GameOnline);
        }
    }
}