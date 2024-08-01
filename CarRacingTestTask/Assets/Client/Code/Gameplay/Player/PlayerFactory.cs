﻿using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Player.Score;
using Client.Code.Gameplay.Player.Time;
using Client.Code.Services.Updater;
using Zenject;

namespace Client.Code.Gameplay.Player
{
    public class PlayerFactory : IAssetReceiver<GameplayConfig>
    {
        private readonly IInstantiator _instantiator;
        private readonly IUpdater _updater;
        private readonly PlayerTimeController _timeController;
        private PlayerScoreController _scoreController;
        private GameplayConfig _config;

        public PlayerFactory(IInstantiator instantiator, IUpdater updater, PlayerTimeController timeController)
        {
            _instantiator = instantiator;
            _updater = updater;
            _timeController = timeController;
        }

        public void Create()
        {
            var canvas = _instantiator.InstantiatePrefabForComponent<PlayerCanvas>(_config.Player.CanvasPrefab);
            _scoreController = _instantiator.Instantiate<PlayerScoreController>();

            _scoreController.Initialize(canvas.ScoreView);
            _timeController.Initialize(canvas.TimeView, _config.LevelTimeSec * 1000);

            _updater.OnFixedUpdateWithDelta += OnUpdate;
        }

        public void Destroy()
        {
            _updater.OnFixedUpdateWithDelta -= OnUpdate;
            _timeController.Dispose();
        }

        public void Receive(GameplayConfig asset) => _config = asset;

        private void OnUpdate(float deltaTime)
        {
            _scoreController.OnUpdate(deltaTime);
            _timeController.OnUpdate();
        }
    }
}