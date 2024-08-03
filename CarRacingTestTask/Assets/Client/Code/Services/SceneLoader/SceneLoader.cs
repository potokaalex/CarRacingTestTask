using Client.Code.Data.Static.Configs.Project;
using Client.Code.Services.Asset.Receiver;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.Code.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader, IAssetReceiver<ProjectConfig>
    {
        private ProjectConfig _config;

        public async UniTask<Scene> LoadSceneAsync(SceneName name)
        {
            var sceneName = _config.SceneNames[name];
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single).ToUniTask();
            return SceneManager.GetSceneByName(sceneName);
        }

        public UniTask UnLoadSceneAsync(SceneName name)
        {
            //TODO: unload scene if Addressables
            return UniTask.CompletedTask;
        }

        public void Receive(ProjectConfig asset) => _config = asset;
    }
}