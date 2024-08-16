using Client.Code.Common.Data;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Game.Data;

namespace Client._dev.GameplayOnline.Game.Car
{
    public struct CarCreateData
    {
        public SpawnPoint SpawnPoint;
        public CarColorType ColorType;
        public bool IsCarSpoilerEnabled;
    }
}