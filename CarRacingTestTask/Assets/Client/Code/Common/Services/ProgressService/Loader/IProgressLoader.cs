using System;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.ProgressService.Loader
{
    public interface IProgressLoader
    {
        UniTask LoadAsync(Action<float> progressReceiver = null);
        void Register(IProgressReader reader);
        void UnRegister(IProgressReader reader);
    }
}