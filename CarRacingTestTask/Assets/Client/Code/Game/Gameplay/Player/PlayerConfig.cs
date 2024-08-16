using UnityEngine;

namespace Client.Code.Game.Gameplay.Player
{
    [CreateAssetMenu(menuName = "Configs/Game/Player", fileName = "PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public PlayerCanvas CanvasPrefab;
    }
}