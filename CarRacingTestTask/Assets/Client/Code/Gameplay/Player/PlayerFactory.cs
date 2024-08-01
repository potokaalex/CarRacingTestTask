using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Player.Score;
using Client.Code.Services.Updater;
using Zenject;

namespace Client.Code.Gameplay.Player
{
    public class PlayerFactory : IAssetReceiver<GameplayConfig>
    {
        private readonly IInstantiator _instantiator;
        private readonly IUpdater _updater;
        private PlayerConfig _config;

        public PlayerFactory(IInstantiator instantiator, IUpdater updater)
        {
            _instantiator = instantiator;
            _updater = updater;
        }

        public void Create()
        {
            var canvas = _instantiator.InstantiatePrefabForComponent<PlayerCanvasObject>(_config.CanvasPrefab);
            var controller = _instantiator.Instantiate<PlayerScoreController>();
            
            controller.Initialize(canvas.ScoreView);
            _updater.OnFixedUpdateWithDelta += controller.OnUpdate;
        }

        public void Receive(GameplayConfig asset) => _config = asset.Player;
    }
}