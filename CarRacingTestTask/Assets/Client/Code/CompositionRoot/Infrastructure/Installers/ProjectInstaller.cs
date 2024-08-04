using System;
using Client.Code.Common.Data.Static.Configs;
using Client.Code.Common.Data.Static.Configs.Gameplay;
using Client.Code.Common.Data.Static.Configs.Project;
using Client.Code.Common.Infrastructure.States;
using Client.Code.Common.Services.Ads.Interstitial;
using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.Services.InputService;
using Client.Code.Common.Services.Logger;
using Client.Code.Common.Services.Logger.Base;
using Client.Code.Common.Services.Progress;
using Client.Code.Common.Services.Progress.Loader;
using Client.Code.Common.Services.Progress.Saver;
using Client.Code.Common.Services.SceneLoader;
using Client.Code.Common.Services.Shop;
using Client.Code.Common.Services.Shop.IAP;
using Client.Code.Common.Services.StateMachine.Factory;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.Services.Unity;
using Client.Code.Common.Services.Updater;
using UnityEngine;
using Zenject;

namespace Client.Code.CompositionRoot.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private ProjectConfig _config;
        [SerializeField] private HubConfig _hubConfig;
        [SerializeField] private GameplayConfig _gameplayConfig;

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
            
            Container.BindInterfacesTo<Updater>().FromNewComponentOnNewGameObject().AsSingle();
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
            Container.BindInterfacesAndSelfTo<IAPFactory>().AsSingle();
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
            Container.Bind<AllAssetsProvider>().AsSingle().WithArguments(new IAsset[] { _config, _hubConfig, _gameplayConfig });
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
#if UNITY_EDITOR
            Container.BindInterfacesTo<AdsInterstitialServiceUnityEditor>().AsSingle();
#else
            Container.BindInterfacesTo<Client.Code.Common.Services.Ads.AdsService>().AsSingle();
            Container.BindInterfacesTo<Client.Code.Common.Services.Ads.Interstitial.AdsInterstitialService>().AsSingle();
#endif
        }
    }
}