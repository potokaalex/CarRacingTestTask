using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Asset.Receiver;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.Code.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader, IAssetReceiver<ProjectConfig>
    {
        private ProjectConfig _config;

        public async UniTask LoadSceneAsync(SceneName name)
        {
            var sceneName = _config.SceneNames[name];
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single).ToUniTask();
        }
        
        public void Receive(ProjectConfig asset) => _config = asset;
    }
}