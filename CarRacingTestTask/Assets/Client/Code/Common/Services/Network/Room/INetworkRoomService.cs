using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Network.Room
{
    public interface INetworkRoomService
    {
        UniTask<NetworkJoinRoomResult> JoinRoomAsync();
    }
}