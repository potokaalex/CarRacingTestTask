using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Unity.Services
{
    public interface IUnityServicesInitializer
    {
        UniTask InitializeAsync();
    }
}