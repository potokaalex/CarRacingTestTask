using Client.Code.Data;
using Client.Code.Data.Hub;
using Client.Code.Hub;
using Client.Code.Services.Asset.Receiver;
using UnityEngine;
using Zenject;

namespace Client.Code.Infrastructure.Installers
{
    public class HubInstaller : MonoInstaller
    {
        [SerializeField] private HubSceneData _sceneData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HubPresenter>().AsSingle();
            Container.BindInterfacesTo<HubFactory>().AsSingle();
            Container.Bind<HubModel>().AsSingle();
            Container.Bind<HubSceneData>().FromInstance(_sceneData).AsSingle();

            Container.BindInterfacesTo<AssetReceiversRegister<HubConfig>>().AsSingle();
        }
    }
}