using System;
using Client.Code.Common.Services.SceneLoader.Data;
using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask<SceneLoadResult> LoadSceneAsync(SceneName name, Action<float> progressReceiver = null);
    }
}