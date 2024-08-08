using System;
using System.Collections.Generic;
using System.IO;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Services.Logger.Base;
using Client.Code.Common.Services.ProgressService.Loader;
using UnityEngine;

namespace Client.Code.Common.Services.ProgressService.Saver
{
    public class ProgressSaver<T> : IProgressSaver<T>, IProgressReader<T> where T : IProgress
    {
        private readonly string _filePath = ProgressConstants.CreateFilePath<T>();
        private readonly List<IProgressWriter<T>> _writers = new();
        private readonly ILogReceiver _logReceiver;
        private T _progress;

        public ProgressSaver(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public void Save(bool isPersistence = true)
        {
            foreach (var writer in _writers)
                writer.OnSave(_progress);

            if (isPersistence)
                SaveProgress();
        }

        private void SaveProgress()
        {
            if (!Directory.Exists(ProgressConstants.DirectoryPath))
                Directory.CreateDirectory(ProgressConstants.DirectoryPath);

            try
            {
                using var writer = new StreamWriter(_filePath, false);
                writer.Write(JsonUtility.ToJson(_progress));
            }
            catch (Exception exception)
            {
                _logReceiver.Log(new LogData { Message = exception.Message });
            }
        }

        public void Register(IProgressWriter<T> writer) => _writers.Add(writer);

        public void UnRegister(IProgressWriter<T> writer) => _writers.Remove(writer);

        public void OnLoad(T progress) => _progress = progress;
    }
}