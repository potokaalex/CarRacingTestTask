using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Game.Data.Static.Configs;
using Client.Code.Game.Gameplay.Player;
using Client.Code.Game.UI.Presenters;
using UnityEngine;
using Zenject;

namespace Client.Code.Game.UI.Factories
{
    public class GameOverScreenFactory : IAssetReceiver<GameConfig>
    {
        private readonly IInstantiator _instantiator;
        private readonly PlayerCoinsController _playerCoinsController;
        private readonly GameOverPresenter _presenter;
        private GameConfig _config;
        private Transform _root;

        public GameOverScreenFactory(IInstantiator instantiator, PlayerCoinsController playerCoinsController, GameOverPresenter presenter)
        {
            _instantiator = instantiator;
            _playerCoinsController = playerCoinsController;
            _presenter = presenter;
        }

        public void Initialize(Transform root) => _root = root;

        public void Create()
        {
            var screen = _instantiator.InstantiatePrefabForComponent<GameOverScreen>(_config.GameOverScreenPrefab, _root);
            screen.CoinsView.Initialize(_playerCoinsController.SessionCoinsCount);

            _presenter.Initialize(screen);
        }

        public void Receive(GameConfig asset) => _config = asset;
    }
}