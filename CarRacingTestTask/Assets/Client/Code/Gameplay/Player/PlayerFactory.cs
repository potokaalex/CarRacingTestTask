using Client.Code.Data.Static.Configs.Gameplay;
using Client.Code.Gameplay.Player.Score;
using Client.Code.Gameplay.Player.Time;
using Client.Code.Services.Asset;
using Client.Code.Services.Asset.Receiver;
using Client.Code.Services.Updater;
using Zenject;

namespace Client.Code.Gameplay.Player
{
    public class PlayerFactory : IAssetReceiver<GameplayConfig>
    {
        private readonly IInstantiator _instantiator;
        private readonly IUpdater _updater;
        private readonly PlayerTimeController _timeController;
        private readonly PlayerCoinsController _coinsController;
        private readonly PlayerScoreController _scoreController;
        private GameplayConfig _config;

        public PlayerFactory(IInstantiator instantiator, IUpdater updater, PlayerTimeController timeController,
            PlayerScoreController playerScoreController, PlayerCoinsController coinsController)
        {
            _instantiator = instantiator;
            _updater = updater;
            _timeController = timeController;
            _scoreController = playerScoreController;
            _coinsController = coinsController;
        }

        public void Create()
        {
            var canvas = _instantiator.InstantiatePrefabForComponent<PlayerCanvas>(_config.Player.CanvasPrefab);
            _scoreController.Initialize(canvas.ScoreView);
            _timeController.Initialize(canvas.TimeView, _config.LevelTimeSec * 1000);

            _updater.OnFixedUpdateWithDelta += OnUpdate;
        }

        public void Destroy()
        {
            _updater.OnFixedUpdateWithDelta -= OnUpdate;
            _timeController.Dispose();
            _coinsController.CollectSessionCoins();
        }

        public void Receive(GameplayConfig asset) => _config = asset;

        private void OnUpdate(float deltaTime)
        {
            _scoreController.OnUpdate(deltaTime);
            _timeController.OnUpdate();
        }
    }
}