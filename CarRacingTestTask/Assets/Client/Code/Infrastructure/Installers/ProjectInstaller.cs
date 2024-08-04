using System;
using Client.Code.AudioManagerService;
using Client.Code.Data.Static.Configs;
using Client.Code.Data.Static.Configs.Gameplay;
using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Ads.Interstitial;
using Client.Code.Services.Asset;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.Asset.Receiver;
using Client.Code.Services.InputService;
using Client.Code.Services.Logger;
using Client.Code.Services.Logger.Base;
using Client.Code.Services.Progress.Loader;
using Client.Code.Services.Progress.Register;
using Client.Code.Services.Progress.Saver;
using Client.Code.Services.SceneLoader;
using Client.Code.Services.Shop;
using Client.Code.Services.Shop.IAP;
using Client.Code.Services.StateMachine.Factory;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.Unity;
using Client.Code.Services.Updater;
using UnityEngine;
using Zenject;

namespace Client.Code.Infrastructure.Installers
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

            Container.BindInterfacesAndSelfTo<InputFactory>().AsSingle();
            
            Container.BindInterfacesTo<Updater>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInterfacesTo<UnityServicesInitializer>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<AudioService>().AsSingle();
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
            Container.BindInterfacesTo<Client.Code.Services.Ads.AdsService>().AsSingle();
            Container.BindInterfacesTo<Client.Code.Services.Ads.Interstitial.AdsInterstitialService>().AsSingle();
#endif
        }
    }
}