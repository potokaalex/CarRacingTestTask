using Client.Code.Data;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.Code.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask<Scene> LoadSceneAsync(SceneName name);
    }
}