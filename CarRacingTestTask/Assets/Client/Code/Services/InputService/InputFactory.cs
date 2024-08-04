using Client.Code.Data;
using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Asset.Receiver;
using Zenject;

namespace Client.Code.Services.InputService
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
            var input = _instantiator.InstantiatePrefabForComponent<InputObject>(_config.InputPrefab);
            _inputService.Initialize(input);
        }

        public void Receive(ProjectConfig asset) => _config = asset;
    }
}