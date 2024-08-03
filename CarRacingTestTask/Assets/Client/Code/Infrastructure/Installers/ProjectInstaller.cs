﻿using System;
using Client.Code.Data;
using Client.Code.Data.Gameplay;
using Client.Code.Services.Ads.Interstitial;
using Client.Code.Services.Asset;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.Asset.Receiver;
using Client.Code.Services.Logger;
using Client.Code.Services.Logger.Base;
using Client.Code.Services.SceneLoader;
using Client.Code.Services.Startup.Runner;
using Client.Code.Services.StateMachine.Factory;
using Client.Code.Services.StateMachine.Global;
using Client.Code.Services.Updater;
using UnityEngine;
using Zenject;

namespace Client.Code.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private ProjectConfig _config;
        [SerializeField] private GameplayConfig _gameplayConfig;

        public override void InstallBindings()
        {
            BindStateMachine();
            BindAssets();
            BindLogger();
            BindAds();
            
            Container.BindInterfacesTo<StartupRunner>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<Updater>().FromNewComponentOnNewGameObject().AsSingle();
        }

        private void BindAssets()
        {
            Container.BindInterfacesTo<AssetLoader<ProjectConfig>>().AsSingle().WithArguments(_config);
            Container.BindInterfacesTo<AssetLoader<GameplayConfig>>().AsSingle().WithArguments(_gameplayConfig);
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