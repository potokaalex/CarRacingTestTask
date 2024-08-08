using System.IO;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Services.Unity;
using UnityEngine;

namespace Client.Code.Common.Services.ProgressService
{
    public static class ProgressStorageConstants
    {
        private const string FilesExtension = "data";
        private const string SaveFolderName = "Saves";

        public static readonly string DirectoryPath;
        public static readonly string FilePath;

        static ProgressStorageConstants()
        {
            var baseDirectoryPath = PlatformsConstants.IsEditor
                ? Directory.GetParent(Application.dataPath).FullName
                : Application.persistentDataPath;
            
            DirectoryPath = Path.Combine(baseDirectoryPath, SaveFolderName);
            
            var fileName = Path.ChangeExtension(nameof(ProgressData), FilesExtension);
            FilePath = Path.Combine(DirectoryPath, fileName);
        }
    }
}