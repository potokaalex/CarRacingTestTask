using Client.Code.Data.Gameplay;
using Client.Code.Gameplay;
using Client.Code.Services.AssetProvider;

namespace Client.Code
{
    public class AssetProviderGameplayConfig : IAssetProvider<GameplayConfig>
    {
        private readonly GameplayConfig _asset;

        public AssetProviderGameplayConfig(GameplayConfig asset) => _asset = asset;

        public GameplayConfig Get() => _asset;
    }
}