using Client.Code.Data.Hub;
using Client.Code.Services.Asset.Receiver;
using UniRx;
using Zenject;

namespace Client.Code.Hub
{
    public class HubUIFactory : IAssetReceiver<HubConfig>
    {
        private readonly IInstantiator _instantiator;
        private readonly HubModel _model;
        private readonly HubWindowsFactory _windowsFactory;
        private HubConfig _config;

        public HubUIFactory(IInstantiator instantiator, HubModel model, HubWindowsFactory windowsFactory)
        {
            _instantiator = instantiator;
            _model = model;
            _windowsFactory = windowsFactory;
        }

        public void Create()
        {
            var canvas = _instantiator.InstantiatePrefabForComponent<HubCanvas>(_config.CanvasPrefab);
            _model.CoinsCount.Subscribe(canvas.CoinsView.SetCoinsCount);
            
            _windowsFactory.Initialize(canvas);
        }
        
        public void Receive(HubConfig asset) => _config = asset;
    }
}