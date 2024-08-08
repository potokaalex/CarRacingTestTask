using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.ProgressService;
using Client.Code.Common.Services.Startup;
using Client.Code.Hub.Data;
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
            BindUI();
            BindAssets();

            Container.BindInterfacesTo<ProgressActorsRegister>().AsSingle();
            Container.BindInterfacesTo<AutoStartupper<HubLoadState>>().AsSingle();
        }

        private void BindAssets()
        {
            Container.BindInterfacesTo<AssetReceiversRegister<HubConfig>>().AsSingle();
            Container.BindInterfacesTo<AssetLoader<HubConfig>>().AsSingle().WithArguments(AssetType.Hub);
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
    }
}