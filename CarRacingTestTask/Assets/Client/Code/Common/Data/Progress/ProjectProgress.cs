using System;
using Client.Code.Common.Services.ProgressService;

namespace Client.Code.Common.Data.Progress
{
    [Serializable]
    public class ProjectProgress : IProgress
    {
        public bool IsMasterAudioEnabled = true;
    }
}