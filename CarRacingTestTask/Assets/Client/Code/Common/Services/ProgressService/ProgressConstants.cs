using System.IO;
using Client.Code.Common.Services.Unity;
using UnityEngine;

namespace Client.Code.Common.Services.ProgressService
{
    public static class ProgressConstants
    {
        private const string FilesExtension = "data";
        private const string SaveFolderName = "Saves";

        public static readonly string DirectoryPath;

        static ProgressConstants()
        {
            var baseDirectoryPath = PlatformsConstants.IsEditor
                ? Directory.GetParent(Application.dataPath).FullName
                : Application.persistentDataPath;

            DirectoryPath = Path.Combine(baseDirectoryPath, SaveFolderName);
        }

        public static string CreateFilePath<T>() where T : IProgress
        {
            var fileName = Path.ChangeExtension(typeof(T).Name, FilesExtension);
            return Path.Combine(DirectoryPath, fileName);
        }
    }
}