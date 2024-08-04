using Client.Code.Common.Data.Static.Configs.Project;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(SceneName name);
    }
}