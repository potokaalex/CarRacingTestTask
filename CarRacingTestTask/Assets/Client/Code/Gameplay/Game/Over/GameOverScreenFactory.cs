using Client.Code.Data.Gameplay;
using UnityEngine;
using Zenject;

namespace Client.Code.Gameplay.Game.Over
{
    public class GameOverScreenFactory : IAssetReceiver<GameplayConfig>
    {
        private readonly IInstantiator _instantiator;
        private Transform _root;
        private GameplayConfig _config;

        public GameOverScreenFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public void Initialize(Transform root) => _root = root;

        public void Create() => _instantiator.InstantiatePrefabForComponent<GameOverScreen>(_config.GameOverScreenPrefab, _root);

        public void Receive(GameplayConfig asset) => _config = asset;
    }
}