using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Network.Connection
{
    public interface INetworkConnectionService
    {
        UniTask<NetworkConnectionResult> ConnectToMasterAsync();
    }
}