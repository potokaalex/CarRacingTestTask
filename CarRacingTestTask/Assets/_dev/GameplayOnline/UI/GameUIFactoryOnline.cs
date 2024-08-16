using Client._dev.GameplayOnline.Data.Static.Configs;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.UI;
using Client.Code.Game.UI.Elements;
using Zenject;

namespace Client._dev.GameplayOnline.UI
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