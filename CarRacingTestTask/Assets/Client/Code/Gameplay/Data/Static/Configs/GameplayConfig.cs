using Client.Code.Common.Services.Asset;
using Client.Code.Gameplay.Game.GameCamera;
using Client.Code.Gameplay.UI;
using UnityEngine;

namespace Client.Code.Gameplay.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Main", fileName = "GameplayConfig", order = 0)]
    public class GameplayConfig : ScriptableObject, IAsset
    {
        public CarConfig Car;
        public PlayerConfig Player;

        public float LevelTimeSec;
        public GameCanvas CanvasPrefab;
        public GameOverScreen GameOverScreenPrefab;
        public CameraController CameraPrefab;
    }
}