using Client.Code.Gameplay.Game.Player;
using UnityEngine;

namespace Client.Code.Gameplay.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Player", fileName = "PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public PlayerCanvas CanvasPrefab;
    }
}