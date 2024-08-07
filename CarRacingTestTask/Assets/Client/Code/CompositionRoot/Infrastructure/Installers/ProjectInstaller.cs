using System;
using Client.Code.Common.Data.Configs;
using Client.Code.Common.Services.Ads;
using Client.Code.Common.Services.Ads.Interstitial;
using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.Services.InputService;
using Client.Code.Common.Services.Logger;
using Client.Code.Common.Services.Logger.Base;
using Client.Code.Common.Services.Network.Connection;
using Client.Code.Common.Services.Network.Room;
using Client.Code.Common.Services.Progress;
using Client.Code.Common.Services.Progress.Loader;
using Client.Code.Common.Services.Progress.Saver;
using Client.Code.Common.Services.SceneLoader;
using Client.Code.Common.Services.Shop;
using Client.Code.Common.Services.Shop.IAP;
using Client.Code.Common.Services.StateMachine.Factory;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.Services.Unity;
using Client.Code.Common.Services.Unity.Services;
using Client.Code.Gameplay.Data.Static.Configs;
using Client.Code.GameplayOnline.Data.Static.Configs;
using Client.Code.Hub.Data;
using UnityEngine;
using Zenject;

namespace Client.Code.CompositionRoot.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private ProjectConfig _config;
        [SerializeField] private HubConfig _hubConfig;
        [SerializeField] private GameplayConfig _gameplayConfig;
        [SerializeField] private GameplayOnlineConfig _gameplayOnlineConfig;

        public override void InstallBindings()
        {
            BindStateMachine();
            BindAssets();
            BindLogger();
            BindAds();
            BindProgress();
            BindShop();
            BindInput();
            BindNetwork();

            Container.BindInterfacesTo<UnityServicesInitializer>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<AudioService>().AsSingle();
        }

        private void BindNetwork()
        {
            Container.BindInterfacesTo<NetworkConnectionService>().AsSingle();
            Container.BindInterfacesTo<NetworkRoomService>().AsSingle();
        }

        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<InputFactory>().AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
        }

        private void BindShop()
        {
            Container.BindInterfacesTo<IAPService>().AsSingle();
            Container.BindInterfacesTo<ShopService>().AsSingle();
        }

        private void BindProgress()
        {
            Container.BindInterfacesTo<ProgressSaver>().AsSingle();
            Container.BindInterfacesTo<ProgressLoader>().AsSingle();
            Container.BindInterfacesTo<ProgressActorsRegister>().AsSingle();
        }

        private void BindAssets()
        {
            Container.Bind<AllAssetsProvider>().AsSingle()
                .WithArguments(new IAsset[] { _config, _hubConfig, _gameplayConfig, _gameplayOnlineConfig });
            Container.BindInterfacesTo<AssetLoader<ProjectConfig>>().AsSingle();
            Container.BindInterfacesTo<AssetReceiversRegister<ProjectConfig>>().AsSingle();
        }

        private void BindLogger()
        {
            Container.BindInterfacesTo<LogReceiver>().AsSingle();
            Container.BindInterfacesTo<LoggerByUnityLog>().AsSingle();
            Container.BindInterfacesTo<LogHandlersRegister>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.Bind(typeof(IGlobalStateMachine), typeof(IDisposable)).To<GlobalStateMachine>().AsSingle();
        }

        private void BindAds()
        {
            if (PlatformsConstants.IsAndroid || PlatformsConstants.IsIOS)
            {
                Container.BindInterfacesTo<AdsService>().AsSingle();
                Container.BindInterfacesTo<AdsInterstitialService>().AsSingle();
            }
            else
                Container.BindInterfacesTo<AdsInterstitialServiceUnityEditor>().AsSingle();
        }
    }
}