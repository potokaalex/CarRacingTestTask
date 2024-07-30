﻿using UnityEngine;

namespace Client.Code.Gameplay.GameplaySpawnPoint
{
    public static class SpawnPointExtensions
    {
        public static SpawnPoint ToSpawnPoint(this Transform transform)
        {
            return new SpawnPoint
            {
                Position = transform.position,
                Rotation = transform.rotation
            };
        }
    }
}