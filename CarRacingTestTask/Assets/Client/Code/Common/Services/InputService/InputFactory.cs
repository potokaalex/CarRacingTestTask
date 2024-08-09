using Client.Code.Common.Data.Configs;
using Client.Code.Common.Services.Asset.Receiver;
using Zenject;

namespace Client.Code.Common.Services.InputService
{
    public class InputFactory : IAssetReceiver<ProjectConfig>
    {
        private readonly IInstantiator _instantiator;
        private readonly IInputService _inputService;
        private ProjectConfig _config;

        public InputFactory(IInstantiator instantiator, IInputService inputService)
        {
            _instantiator = instantiator;
            _inputService = inputService;
        }

        public void Create()
        {
            var input = _instantiator.InstantiatePrefabForComponent<InputObject>(_config.Input.InputPrefab);
            _inputService.Initialize(input);
        }

        public void Receive(ProjectConfig asset) => _config = asset;
    }
}