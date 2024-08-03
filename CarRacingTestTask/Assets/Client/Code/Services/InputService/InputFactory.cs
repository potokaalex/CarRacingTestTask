using Client.Code.Data;
using Client.Code.Services.Asset.Receiver;
using Zenject;

namespace Client.Code.Services.InputService
{
    public class InputFactory : IAssetReceiver<ProjectConfig>
    {
        private readonly IInstantiator _instantiator;
        private ProjectConfig _config;

        public InputFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public void Create() => _instantiator.InstantiatePrefab(_config.InputPrefab);

        public void Receive(ProjectConfig asset) => _config = asset;
    }
}