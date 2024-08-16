using Client.Code.Game.Gameplay.Player;
using UnityEngine;

namespace Client.Code.Game.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Game/Player", fileName = "PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public PlayerCanvas CanvasPrefab;
    }
}