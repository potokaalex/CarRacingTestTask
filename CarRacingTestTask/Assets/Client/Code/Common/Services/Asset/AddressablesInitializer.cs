using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Client.Code.Common.Services.Asset
{
    public class AddressablesInitializer
    {
        public async UniTask InitializeAsync() => await Addressables.InitializeAsync(false).ToUniTask();
    }
}