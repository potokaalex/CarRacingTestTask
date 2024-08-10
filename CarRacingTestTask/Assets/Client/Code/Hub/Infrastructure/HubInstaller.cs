using Client.Code.Common.Data.Progress;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.Asset.Data;
using Client.Code.Common.Services.Asset.Loader;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.ProgressService;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.ProgressService.Saver;
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
            BindProgress();

            Container.BindInterfacesTo<AutoStartupper<HubLoadState>>().AsSingle();
        }

        private void BindProgress()
        {
            Container.BindInterfacesTo<ProgressSaver<PlayerProgress>>().AsSingle();
            Container.BindInterfacesTo<ProgressLoader<PlayerProgress>>().AsSingle();
            
            Container.BindInterfacesTo<ProgressActorsRegister<PlayerProgress>>().AsSingle();
            Container.BindInterfacesTo<ProgressActorsRegister<ProjectProgress>>().AsSingle();
        }

        private void BindAssets()
        {
            Container.BindInterfacesTo<AssetReceiversRegister<HubConfig>>().AsSingle();
            Container.BindInterfacesTo<AssetLoader<HubConfig>>().AsSingle().WithArguments(AssetLabelType.Hub);
        }

        private void BindUI()
        {
            Container.BindInterfacesAndSelfTo<HubUIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<HubWindowsFactory>().AsSingle();
            Container.BindInterfacesTo<HubSelectLevelWindowFactory>().AsSingle();
            Container.BindInterfacesTo<HubCustomizationWindowFactory>().AsSingle();
            Container.BindInterfacesTo<HubShopWindowFactory>().AsSingle();
            Container.BindInterfacesTo<HubSettingsWindowFactory>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<HubModel>().AsSingle();

            Container.BindInterfacesTo<HubPresenter>().AsSingle();
            Container.BindInterfacesTo<HubCustomizationPresenter>().AsSingle();
            Container.BindInterfacesTo<HubSettingsPresenter>().AsSingle();
            Container.BindInterfacesTo<HubShopPresenter>().AsSingle();
        }
    }
}