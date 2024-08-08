using System;
using Client.Code.Common.Services.Asset.Data;
using Client.Code.Common.Services.Asset.Receiver;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Asset.Loader
{
    public interface IAssetLoader<out T> where T : IAsset
    {
        UniTask<LoadAssetResult> LoadAsync(Action<float> progressReceiver = null);
        void UnloadAssets();
        void RegisterReceiver(IAssetReceiver<T> receiver);
        void UnRegisterReceiver(IAssetReceiver<T> receiver);
    }
}