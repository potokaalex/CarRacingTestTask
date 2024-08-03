using Client.Code.Data.Static.Constants;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using Zenject;

namespace Client.Code.Services.Unity
{
    public class UnityServicesInitializer : IInitializable
    {
        public void Initialize()
        {
            var options = new InitializationOptions().SetEnvironmentName(ProjectConstants.UnityServicesEnvironment);
            UnityServices.InitializeAsync(options);
        }
    }
}