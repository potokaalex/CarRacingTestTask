using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Unity
{
    public interface IUnityServicesInitializer
    {
        UniTask InitializeAsync();
    }
}