﻿using Client.Code.Data.Hub;
using Client.Code.Hub;
using Client.Code.Infrastructure.States.Hub;
using Client.Code.Services.Asset.Receiver;
using Client.Code.Services.Progress;
using Client.Code.Services.Startup.Delayed;
using Client.Code.Services.StateMachine;
using Client.Code.Services.StateMachine.Factory;
using Zenject;

namespace Client.Code.Infrastructure.Installers
{
    public class HubInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindUI();
            
            Container.BindInterfacesTo<ProgressActorsRegister>().AsSingle();
            Container.BindInterfacesTo<AssetReceiversRegister<HubConfig>>().AsSingle();
            Container.BindInterfacesTo<DelayedStartupper<HubEnterState>>().AsSingle();
        }

        private void BindUI()
        {
            Container.BindInterfacesAndSelfTo<HubUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<HubWindowsFactory>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<HubModel>().AsSingle();
            Container.BindInterfacesTo<HubPresenter>().AsSingle();
        }
        
        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}