using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Infrastructure.States
{
    public interface INetworkRoomService
    {
        UniTask<NetworkJoinRoomResult> JoinRoomAsync();
    }
}