using Client.Code.Common.Data.Static.Configs;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Progress;
using Client.Code.Common.Services.Startup;
using Client.Code.Common.Services.StateMachine;
using Client.Code.Common.Services.StateMachine.Factory;
using Client.Code.Common.Services.Updater;
using Client.Code.Hub.Infrastructure.States;
using Client.Code.Hub.UI;
using Client.Code.Hub.UI.Factories;
using Client.Code.Hub.UI.Presenters;
using Zenject;

namespace Client.Code.Hub.Infrastructure
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