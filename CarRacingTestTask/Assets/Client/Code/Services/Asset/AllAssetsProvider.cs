using System;

namespace Client.Code.Services.Asset
{
    //TODO: remove if Addressables
    public class AllAssetsProvider
    {
        private readonly IAsset[] _assets;
        
        public AllAssetsProvider(params IAsset[] assets) => _assets = assets;
        
        public T Get<T>() where T : IAsset
        {
            foreach (var asset in _assets)
                if(asset is T typedAsset)
                    return typedAsset;

            throw new Exception($"Cant find asset with type: {typeof(T)}.");
        }
    }
}