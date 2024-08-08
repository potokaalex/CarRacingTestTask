using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Gameplay.UI;
using Client.Code.GameplayOnline.Data.Static.Configs;
using Zenject;

namespace Client.Code.GameplayOnline.UI
{
    public class GameUIFactoryOnline : IAssetReceiver<GameplayOnlineConfig>
    {
        private readonly IInstantiator _instantiation;
        private GameplayOnlineConfig _config;

        public GameUIFactoryOnline(IInstantiator instantiation) => _instantiation = instantiation;

        public void Create() => _instantiation.InstantiatePrefabForComponent<GameCanvas>(_config.CanvasPrefab);

        public void Receive(GameplayOnlineConfig asset) => _config = asset;
    }
}