using System.Collections.Generic;
using Client.Code.Services.Asset.Receiver;

namespace Client.Code.Services.Asset.Loader
{
    public class AssetLoader<T> : IAssetLoader<T> where T : IAsset
    {
        private readonly List<IAssetReceiver<T>> _receivers = new();
        private readonly T _asset;
        
        public AssetLoader(T asset) => _asset = asset;
        
        public void Load()
        {
            foreach (var receiver in _receivers)
                receiver.Receive(_asset);
        }

        public void RegisterReceiver(IAssetReceiver<T> receiver) => _receivers.Add(receiver);

        public void UnRegisterReceiver(IAssetReceiver<T> receiver) => _receivers.Remove(receiver);
    }
}