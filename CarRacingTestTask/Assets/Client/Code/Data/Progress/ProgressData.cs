﻿using System;

namespace Client.Code.Data.Progress
{
    [Serializable]
    public class ProgressData
    {
        public ProjectProgress Project = new();
        public PlayerProgress Player = new();
    }
}