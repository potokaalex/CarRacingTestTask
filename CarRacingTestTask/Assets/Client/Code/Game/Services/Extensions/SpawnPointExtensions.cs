using Client.Code.Game.Data;
using UnityEngine;

namespace Client.Code.Game.Services.Extensions
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