using System;
using Client.Code.Common.Data.Progress.Player;

namespace Client.Code.Common.Data.Progress
{
    [Serializable]
    public class ProgressData
    {
        public ProjectProgress Project = new();
        public PlayerProgress Player = new();
    }
}