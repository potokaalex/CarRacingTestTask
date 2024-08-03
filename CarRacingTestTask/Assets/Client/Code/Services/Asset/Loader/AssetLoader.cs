using System.Collections.Generic;
using Client.Code.Services.Asset.Receiver;
using Zenject;

namespace Client.Code.Services.Asset.Loader
{
    public class AssetLoader<T> : IAssetLoader<T>, IInitializable where T : IAsset
    {
        private readonly List<IAssetReceiver<T>> _receivers = new();
        private readonly AllAssetsProvider _assetsProvider;
        private T _asset;

        public AssetLoader(AllAssetsProvider assetsProvider) => _assetsProvider = assetsProvider;
        
        public void Initialize() => _asset = _assetsProvider.Get<T>();

        public void Load()
        {
            foreach (var receiver in _receivers)
                receiver.Receive(_asset);
        }

        public void RegisterReceiver(IAssetReceiver<T> receiver) => _receivers.Add(receiver);

        public void UnRegisterReceiver(IAssetReceiver<T> receiver) => _receivers.Remove(receiver);
    }
}