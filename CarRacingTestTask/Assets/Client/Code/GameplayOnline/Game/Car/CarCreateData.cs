using Client.Code.Common.Data;
using Client.Code.Gameplay.Game.GameSpawnPoint;

namespace Client.Code.GameplayOnline.Game.Car
{
    public struct CarCreateData
    {
        public SpawnPoint SpawnPoint;
        public CarColorType ColorType;
        public bool IsCarSpoilerEnabled;
    }
}