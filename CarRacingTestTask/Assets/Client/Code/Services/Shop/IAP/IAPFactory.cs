using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Asset.Receiver;
using Zenject;

namespace Client.Code.Services.Shop.IAP
{
    public class IAPFactory : IAssetReceiver<ProjectConfig>
    {
        private readonly IIAPService _service;
        private readonly IInstantiator _instantiator;
        private ProjectConfig _config;

        public IAPFactory(IIAPService service, IInstantiator instantiator)
        {
            _service = service;
            _instantiator = instantiator;
        }

        public void Create()
        {
            var iap = _instantiator.InstantiatePrefabForComponent<IAPObject>(_config.Shop.IAPPrefab);
            _service.Initialize(iap);
        }
        
        public void Receive(ProjectConfig asset) => _config = asset;
    }
}