﻿using Client.Code.Gameplay.Player;
using UnityEngine;

namespace Client.Code.Data.Static.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Player", fileName = "PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public PlayerCanvas CanvasPrefab;
    }
}