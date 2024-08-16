using Client.Code.Common.Services.Asset;
using Client.Code.Game.UI;
using UnityEngine;

namespace Client.Code.Game.Data.Static.Configs
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