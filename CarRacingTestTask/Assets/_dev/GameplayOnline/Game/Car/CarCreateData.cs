using Client.Code.Common.Data;
using Client.Code.Game.Gameplay.GameSpawnPoint;

namespace Client._dev.GameplayOnline.Game.Car
{
    public struct CarCreateData
    {
        public SpawnPoint SpawnPoint;
        public CarColorType ColorType;
        public bool IsCarSpoilerEnabled;
    }
}