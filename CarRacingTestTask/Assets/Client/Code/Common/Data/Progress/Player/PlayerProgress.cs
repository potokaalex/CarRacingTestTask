using System;

namespace Client.Code.Common.Data.Progress.Player
{
    [Serializable]
    public class PlayerProgress
    {
        public ShopProgress Shop = new();
        public CarColorType CarColor = CarColorType.Purple;
        public bool IsCarSpoilerEnabled = false;
        public int CoinsCount = 0;
    }
}