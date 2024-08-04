using Unity.Services.Core;
using Unity.Services.Core.Environments;
using Zenject;

namespace Client.Code.Common.Services.Unity
{
    public class UnityServicesInitializer : IInitializable
    {
        public void Initialize()
        {
            var options = new InitializationOptions().SetEnvironmentName(UnityServicesConstants.Environment);
            UnityServices.InitializeAsync(options);
        }
    }
}