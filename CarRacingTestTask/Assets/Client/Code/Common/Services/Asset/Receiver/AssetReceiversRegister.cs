using System;
using System.Collections.Generic;
using Client.Code.Common.Services.Asset.Loader;
using Zenject;

namespace Client.Code.Common.Services.Asset.Receiver
{
    public class AssetReceiversRegister<T> : IInitializable, IDisposable where T : IAsset
    {
        private readonly List<IAssetReceiver<T>> _receivers;
        private readonly IAssetLoader<T> _loader;

        public AssetReceiversRegister(List<IAssetReceiver<T>> receivers, IAssetLoader<T> loader)
        {
            _receivers = receivers;
            _loader = loader;
        }

        public void Initialize()
        {
            foreach (var receiver in _receivers)
                _loader.RegisterReceiver(receiver);
        }

        public void Dispose()
        {
            foreach (var receiver in _receivers)
                _loader.UnRegisterReceiver(receiver);
        }
    }
}