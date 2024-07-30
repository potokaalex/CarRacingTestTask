using System;
using Client.Code.Data;
using Client.Code.Services.AssetProvider;
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

        public override void InstallBindings()
        {
            BindStateMachine();
            Container.BindInterfacesTo<AssetProviderProjectConfig>().AsSingle().WithArguments(_config);
            Container.BindInterfacesTo<StartupRunner>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<Updater>().FromNewComponentOnNewGameObject().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.Bind(typeof(IGlobalStateMachine), typeof(IDisposable)).To<GlobalStateMachine>().AsSingle();
        }
    }
}