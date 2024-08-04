using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Progress;
using Client.Code.Common.Services.Startup;
using Client.Code.Gameplay.Game.Car.Controllers;
using Client.Code.Gameplay.UI.Presenters;
using Client.Code.GameplayOnline.Data;
using Client.Code.GameplayOnline.Data.Static.Configs;
using Client.Code.GameplayOnline.Game.Car;
using Client.Code.GameplayOnline.Game.GameCamera;
using Client.Code.GameplayOnline.Infrastructure.States;
using Client.Code.GameplayOnline.UI;
using UnityEngine;
using Zenject;

namespace Client.Code.GameplayOnline.Infrastructure
{
    public class GameplayOnlineInstaller : MonoInstaller
    {
        [SerializeField] private GameplayOnlineSceneData _sceneData;
        
        public override void InstallBindings()
        {
            BindAssets();
            BindUI();
            BindGame();
            
            Container.BindInterfacesTo<ProgressActorsRegister>().AsSingle();
            Container.Bind<GameplayOnlineSceneData>().FromInstance(_sceneData).AsSingle();
            Container.BindInterfacesTo<AutoStartupper<GameplayOnlineLoadState>>().AsSingle();
        }

        private void BindGame()
        {
            BindCar();
            Container.BindInterfacesTo<CameraFactoryOnline>().AsSingle();
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
            Container.BindInterfacesTo<AssetLoader<GameplayOnlineConfig>>().AsSingle();
        }
    }
}