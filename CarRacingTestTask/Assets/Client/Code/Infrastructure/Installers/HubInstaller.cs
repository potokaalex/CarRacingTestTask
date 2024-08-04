using Client.Code.Data.Static.Configs;
using Client.Code.Hub;
using Client.Code.Hub.Factories;
using Client.Code.Hub.Presenters;
using Client.Code.Infrastructure.States.Hub;
using Client.Code.Services.Asset.Loader;
using Client.Code.Services.Asset.Receiver;
using Client.Code.Services.Progress.Register;
using Client.Code.Services.Startup.Auto;
using Client.Code.Services.StateMachine;
using Client.Code.Services.StateMachine.Factory;
using Client.Code.Services.Updater;
using Zenject;

namespace Client.Code.Infrastructure.Installers
{
    public class HubInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindUI();
            BindAssets();
            
            Container.BindInterfacesTo<ProgressActorsRegister>().AsSingle();
            Container.BindInterfacesTo<AutoStartupper<HubLoadState>>().AsSingle();
            Container.BindInterfacesTo<Updater>().FromNewComponentOnNewGameObject().AsSingle();
        }

        private void BindAssets()
        {
            Container.BindInterfacesTo<AssetReceiversRegister<HubConfig>>().AsSingle();
            Container.BindInterfacesTo<AssetLoader<HubConfig>>().AsSingle();
        }

        private void BindUI()
        {
            Container.BindInterfacesAndSelfTo<HubUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<HubWindowsFactory>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<HubModel>().AsSingle();
            
            Container.BindInterfacesTo<HubPresenter>().AsSingle();
            Container.BindInterfacesTo<HubCustomizationPresenter>().AsSingle();
            Container.BindInterfacesTo<HubSettingsPresenter>().AsSingle();
            Container.BindInterfacesTo<HubShopPresenter>().AsSingle();
        }
        
        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}