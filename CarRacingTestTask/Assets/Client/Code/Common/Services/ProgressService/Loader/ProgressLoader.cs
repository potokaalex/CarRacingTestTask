using System;
using System.Collections.Generic;
using System.IO;
using Client.Code.Common.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Client.Code.Common.Services.ProgressService.Loader
{
    public class ProgressLoader<T> : IProgressLoader<T> where T : IProgress, new()
    {
        private readonly string _filePath = ProgressConstants.CreateFilePath<T>();
        private readonly List<IProgressReader<T>> _readers = new();
        private readonly ILogReceiver _logReceiver;
        private T _progress;

        private ProgressLoader(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public async UniTask LoadAsync(Action<float> progressReceiver = null)
        {
            _progress ??= await LoadProgress();

            foreach (var reader in _readers)
                reader.OnLoad(_progress);

            progressReceiver?.Invoke(1);
        }

        private async UniTask<T> LoadProgress()
        {
            var defaultProgress = new T();

            if (!File.Exists(_filePath))
                return defaultProgress;

            try
            {
                using var reader = new StreamReader(_filePath, false);
                var readData = await reader.ReadToEndAsync().AsUniTask();
                var result = JsonUtility.FromJson<T>(readData);
                if (result != null)
                    return result;
            }
            catch (Exception exception)
            {
                _logReceiver.Log(new LogData { Message = exception.Message });
            }

            return defaultProgress;
        }

        public void Register(IProgressReader<T> reader) => _readers.Add(reader);

        public void UnRegister(IProgressReader<T> reader) => _readers.Remove(reader);
    }
}