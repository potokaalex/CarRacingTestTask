using System;
using System.Collections.Generic;
using Client.Code.Common.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using Zenject;

namespace Client.Code.Common.Services.Network.Room
{
    public class NetworkRoomService : INetworkRoomService, IMatchmakingCallbacks, IInitializable, IDisposable
    {
        private readonly ILogReceiver _logReceiver;
        private NetworkJoinRoomResult _joinResult;

        public NetworkRoomService(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public void Initialize() => PhotonNetwork.AddCallbackTarget(this);

        public void Dispose() => PhotonNetwork.RemoveCallbackTarget(this);

        public async UniTask<NetworkJoinRoomResult> JoinRoomAsync()
        {
            _joinResult = NetworkJoinRoomResult.None;

            PhotonNetwork.JoinOrCreateRoom(NetworkConstants.StandardRoomName, new RoomOptions(), TypedLobby.Default);

            await UniTask.WaitUntil(() => _joinResult != NetworkJoinRoomResult.None);
            return _joinResult;
        }

        public void OnCreateRoomFailed(short returnCode, string message) => _logReceiver.Log(new LogData { Message = message });

        public void OnJoinedRoom() => _joinResult = NetworkJoinRoomResult.Success;

        public void OnJoinRoomFailed(short returnCode, string message)
        {
            _joinResult = NetworkJoinRoomResult.Fail;
            _logReceiver.Log(new LogData { Message = message });
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
        }

        public void OnCreatedRoom()
        {
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
        }

        public void OnLeftRoom()
        {
        }
    }
}