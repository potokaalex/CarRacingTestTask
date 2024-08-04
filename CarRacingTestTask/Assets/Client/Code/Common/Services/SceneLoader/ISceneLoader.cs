using Client.Code.Common.Data;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(SceneName name);
    }
}