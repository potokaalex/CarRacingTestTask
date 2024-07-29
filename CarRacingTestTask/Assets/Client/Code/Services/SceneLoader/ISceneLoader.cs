using Cysharp.Threading.Tasks;

namespace Client.Code.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string sceneName);
    }
}