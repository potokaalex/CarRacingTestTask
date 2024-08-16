using Client.Code.Common.Services.Asset;
using Client.Code.Game.Data.Static.Configs;
using Client.Code.Game.UI;
using Client.Code.Game.UI.Elements;
using UnityEngine;

namespace Client._dev.GameplayOnline.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Online/Main", fileName = "GameplayOnlineConfig", order = 0)]
    public class GameplayOnlineConfig : ScriptableObject, IAsset
    {
        public CarConfig Car;
        public GameCanvas CanvasPrefab;
        public CameraController CameraPrefab;
    }
}