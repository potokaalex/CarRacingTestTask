using Client.Code.Common.Data;
using Client.Code.Common.Services.SceneLoader;
using Client.Code.Common.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Infrastructure.States
{
    public class HubStateGlobal : IStateAsync
    {
        private readonly ISceneLoader _sceneLoader;

        public HubStateGlobal(ISceneLoader sceneLoader) => _sceneLoader = sceneLoader;

        public UniTask Enter() => _sceneLoader.LoadSceneAsync(SceneName.Hub);
    }
}