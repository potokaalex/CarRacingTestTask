using System.IO;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Services.Unity;
using UnityEngine;

namespace Client.Code.Common.Services.Progress
{
    public static class ProgressStorageConstants
    {
        private const string FilesExtension = "data";
        private const string SaveFolderName = "Saves";
        
        private static readonly string _fileName = Path.ChangeExtension(nameof(ProgressData), FilesExtension);
        private static readonly string _baseDirectoryPath;
        
        public static readonly string DirectoryPath = Path.Combine(_baseDirectoryPath, SaveFolderName);
        public static readonly string FilePath = Path.Combine(DirectoryPath, _fileName);

        static ProgressStorageConstants()
        {
            if (PlatformsConstants.IsEditor)
                _baseDirectoryPath = Directory.GetParent(Application.dataPath)?.FullName;
            else
                _baseDirectoryPath = Application.persistentDataPath;
        }
    }
}