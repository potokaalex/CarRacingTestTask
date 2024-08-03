using Client.Code.Data;
using Client.Code.Data.Static.Configs.Project;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.Code.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask<Scene> LoadSceneAsync(SceneName name);
        UniTask UnLoadSceneAsync(SceneName name);
    }
}