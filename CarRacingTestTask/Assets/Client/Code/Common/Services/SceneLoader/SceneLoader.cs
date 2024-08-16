using System;
using Client.Code.Common.Data;
using Client.Code.Common.Services.Asset.Receiver;
using Client.Code.Common.Services.Logger.Base;
using Client.Code.Common.Services.SceneLoader.Data;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Client.Code.Common.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader, IAssetReceiver<ProjectConfig>
    {
        private readonly ILogReceiver _logReceiver;
        private ProjectConfig _config;

        public SceneLoader(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public async UniTask<SceneLoadResult> LoadSceneAsync(SceneName name, Action<float> progressReceiver = null)
        {
            try
            {
                var progress = Progress.Create(progressReceiver);
                var key = _config.Scene.Keys[name];
                var handle = Addressables.LoadSceneAsync(key, releaseMode: SceneReleaseMode.ReleaseSceneWhenSceneUnloaded);
                await handle.ToUniTask(progress: progress);
                return SceneLoadResult.Success;
            }
            catch (Exception exception)
            {
                _logReceiver.Log(new LogData { Message = exception.Message });
                return SceneLoadResult.Fail;
            }
        }

        public void Receive(ProjectConfig asset) => _config = asset;
    }
}