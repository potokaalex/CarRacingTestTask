using System.IO;
using Client.Code.Common.Data.Progress;
using UnityEngine;

namespace Client.Code.Common.Services.Progress
{
    public static class ProgressStorageConstants
    {
        private const string FilesExtension = "data";

        public static readonly string DirectoryPath = Path.Combine(Application.persistentDataPath, "Saves");
        public static readonly string FileName = Path.ChangeExtension(nameof(ProgressData), FilesExtension);
        public static readonly string FilePath = Path.Combine(DirectoryPath, FileName);
    }
}