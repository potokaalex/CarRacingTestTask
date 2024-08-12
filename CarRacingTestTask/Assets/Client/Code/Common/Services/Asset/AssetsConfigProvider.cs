using Client.Code.Common.Services.Asset.Data;

namespace Client.Code.Common.Services.Asset
{
    public class AssetsConfigProvider
    {
        private readonly AssetsConfig _config;

        public AssetsConfigProvider(AssetsConfig config) => _config = config;

        public AssetsConfig Get() => _config;
    }
}