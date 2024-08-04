using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Infrastructure.States
{
    public interface INetworkConnectionService
    {
        UniTask<NetworkConnectionResult> ConnectToMasterAsync();
    }
}