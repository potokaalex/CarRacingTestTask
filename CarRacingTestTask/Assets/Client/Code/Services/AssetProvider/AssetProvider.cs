using Client.Code.Data;
using Client.Code.Infrastructure.States;

namespace Client.Code.Services.AssetProvider
{
    public class AssetProviderProjectConfig : IAssetProvider<ProjectConfig>
    {
        private readonly ProjectConfig _asset;

        public AssetProviderProjectConfig(ProjectConfig asset) => _asset = asset;

        public ProjectConfig Get() => _asset;
    }
}