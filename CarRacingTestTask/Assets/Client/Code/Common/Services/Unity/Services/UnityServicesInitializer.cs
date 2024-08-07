using Cysharp.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Core.Environments;

namespace Client.Code.Common.Services.Unity.Services
{
    public class UnityServicesInitializer : IUnityServicesInitializer
    {
        public async UniTask InitializeAsync()
        {
            var options = new InitializationOptions().SetEnvironmentName(UnityServicesConstants.Environment);
            await UnityServices.InitializeAsync(options).AsUniTask();
        }
    }
}