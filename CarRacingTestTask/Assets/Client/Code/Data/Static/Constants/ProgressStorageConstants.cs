using System.IO;
using Client.Code.Data.Progress;
using UnityEngine;

namespace Client.Code.Data.Static.Constants
{
    public static class ProgressStorageConstants
    {
        private const string FilesExtension = "data";

        public static readonly string DirectoryPath = Path.Combine(Application.dataPath, "Saves");
        public static readonly string FileName = Path.ChangeExtension(nameof(ProgressData), FilesExtension);
        public static readonly string FilePath = Path.Combine(DirectoryPath, FileName);
    }
}