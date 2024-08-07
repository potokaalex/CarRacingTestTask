using System.IO;
using Client.Code.Common.Data.Progress;
using UnityEngine;

namespace Client.Code.Common.Services.Progress
{
    public static class ProgressStorageConstants
    {
        private const string FilesExtension = "data";
        private const string SaveFolderName = "Saves";
        
        private static readonly string _fileName = Path.ChangeExtension(nameof(ProgressData), FilesExtension);
#if UNITY_EDITOR
        private static readonly string _baseDirectoryPath = Directory.GetParent(Application.dataPath)?.FullName;
#else
        private static readonly string _baseDirectoryPath = Application.persistentDataPath;
#endif
        
        public static readonly string DirectoryPath = Path.Combine(_baseDirectoryPath, SaveFolderName);
        public static readonly string FilePath = Path.Combine(DirectoryPath, _fileName);
    }
}