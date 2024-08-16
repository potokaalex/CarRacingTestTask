using System;
using Client.Code.Common.Data.Configs;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Services.Ads;
using Client.Code.Common.Services.Ads.Interstitial;
using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.Asset.Data;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.Services.CursorService;
using Client.Code.Common.Services.InputService;
using Client.Code.Common.Services.LoadingScreen;
using Client.Code.Common.Services.Logger;
using Client.Code.Common.Services.Logger.Base;
using Client.Code.Common.Services.Network.Connection;
using Client.Code.Common.Services.Network.Room;
using Client.Code.Common.Services.ProgressService;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Common.Services.SceneLoader;
using Client.Code.Common.Services.Shop;
using Client.Code.Common.Services.Shop.IAP;
using Client.Code.Common.Services.StateMachine.Factory;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.Services.Unity;
using Client.Code.Common.Services.Unity.Services;
using UnityEngine;
using Zenject;
using Cursor = UnityEngine.UIElements.Cursor;

namespace Client.Code.CompositionRoot.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AssetsConfig _assetsConfig;

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
            Container.BindInterfacesTo<LoadingScreenFactory>().AsSingle();
            Container.Bind<ICursorService>().To<CursorService>().AsSingle();
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
            Container.BindInterfacesTo<ProgressSaver<ProjectProgress>>().AsSingle();
            Container.BindInterfacesTo<ProgressLoader<ProjectProgress>>().AsSingle();
            Container.BindInterfacesTo<ProgressActorsRegister<ProjectProgress>>().AsSingle();
        }

        private void BindAssets()
        {
            Container.Bind<AssetsConfigProvider>().AsSingle().WithArguments(_assetsConfig);
            Container.Bind<AddressablesInitializer>().AsSingle();
            Container.BindInterfacesTo<AssetLoader<ProjectConfig>>().AsSingle().WithArguments(AssetLabelType.Project);
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