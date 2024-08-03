using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Player;
using Client.Code.Gameplay.Player.Score;
using Client.Code.Services.Asset;
using Client.Code.Services.Asset.Receiver;
using UnityEngine;
using Zenject;

namespace Client.Code.Gameplay.Game.Over
{
    public class GameOverScreenFactory : IAssetReceiver<GameplayConfig>
    {
        private readonly IInstantiator _instantiator;
        private readonly PlayerCoinsController _playerCoinsController;
        private readonly GameOverPresenter _presenter;
        private GameplayConfig _config;
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

        public void Receive(GameplayConfig asset) => _config = asset;
    }
}