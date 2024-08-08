using System;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.ProgressService.Loader
{
    public interface IProgressLoader<out T> where T : IProgress
    {
        UniTask LoadAsync(Action<float> progressReceiver = null);
        void Register(IProgressReader<T> reader);
        void UnRegister(IProgressReader<T> reader);
    }
}