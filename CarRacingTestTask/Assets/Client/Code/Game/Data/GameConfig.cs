using Client.Code.Common.Services.Asset;
using Client.Code.Game.Gameplay.Car;
using Client.Code.Game.Gameplay.GameplayCamera;
using Client.Code.Game.Gameplay.Player;
using Client.Code.Game.UI.Elements;
using UnityEngine;

namespace Client.Code.Game.Data
{
    [CreateAssetMenu(menuName = "Configs/Game/Main", fileName = "GameConfig", order = 0)]
    public class GameConfig : ScriptableObject, IAsset
    {
        public CarConfig Car;
        public PlayerConfig Player;

        public float LevelTimeSec;
        public GameCanvas CanvasPrefab;
        public GameOverScreen GameOverScreenPrefab;
        public CameraConfig Camera;
    }
}