using System;
using System.Collections.Generic;
using Client.Code.Common.Services.Asset.Data;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Client.Code.Common.Services.Asset.Loader
{
    public class AssetLoader<T> : IAssetLoader<T>, IInitializable where T : IAsset
    {
        private readonly List<IAssetReceiver<T>> _receivers = new();
        private readonly AssetsConfigProvider _configProvider;
        private readonly ILogReceiver _logReceiver;
        private readonly AssetLabelType _labelType;
        private AssetsConfig _config;
        private AsyncOperationHandle<IList<object>> _handle;

        public AssetLoader(AssetsConfigProvider configProvider, ILogReceiver logReceiver, AssetLabelType labelType)
        {
            _configProvider = configProvider;
            _logReceiver = logReceiver;
            _labelType = labelType;
        }

        public void Initialize() => _config = _configProvider.Get();

        public async UniTask<LoadAssetResult> LoadAsync(Action<float> progressReceiver = null)
        {
            try
            {
                _handle = Addressables.LoadAssetsAsync<object>(_config.Labels[_labelType], OnAssetLoad, true);
                await _handle.ToUniTask();
                progressReceiver?.Invoke(1);
                return LoadAssetResult.Success;
            }
            catch (Exception exception)
            {
                _logReceiver.Log(new LogData { Message = $"Load asset exception: {exception.Message}." });
                return LoadAssetResult.Fail;
            }
        }

        public void UnloadAssets() => _handle.Release();

        public void RegisterReceiver(IAssetReceiver<T> receiver) => _receivers.Add(receiver);

        public void UnRegisterReceiver(IAssetReceiver<T> receiver) => _receivers.Remove(receiver);

        private void OnAssetLoad(object asset)
        {
            if (asset == null)
                return;

            foreach (var receiver in _receivers)
                if (asset is T typedAsset)
                    receiver.Receive(typedAsset);
        }
    }
}