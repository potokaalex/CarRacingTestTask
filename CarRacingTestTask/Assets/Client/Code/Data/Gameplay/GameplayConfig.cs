using Client.Code.Gameplay;
using Client.Code.Gameplay.Game;
using Client.Code.Gameplay.Game.Over;
using Client.Code.Services.AssetProvider;
using UnityEngine;

namespace Client.Code.Data.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Gameplay", fileName = "GameplayConfig", order = 0)]
    public class GameplayConfig : ScriptableObject, IAsset
    {
        public CarConfig Car;
        public PlayerConfig Player;

        public float LevelTimeSec;
        public GameCanvas CanvasPrefab;
        public GameOverScreen GameOverScreenPrefab;
    }
}