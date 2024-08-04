using System;
using System.Collections.Generic;
using Client.Code.Common.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using Zenject;

namespace Client.Code.Common.Services.Network.Connection
{
    public class NetworkConnectionService : INetworkConnectionService, IConnectionCallbacks, IInitializable, IDisposable
    {
        private readonly ILogReceiver _logReceiver;
        private NetworkConnectionResult _result;

        public NetworkConnectionService(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public void Initialize() => PhotonNetwork.AddCallbackTarget(this);

        public void Dispose() => PhotonNetwork.RemoveCallbackTarget(this);

        public async UniTask<NetworkConnectionResult> ConnectToMasterAsync()
        {
            _result = NetworkConnectionResult.None;

            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

            await UniTask.WaitUntil(() => _result != NetworkConnectionResult.None);
            return _result;
        }

        public void OnConnectedToMaster() => _result = NetworkConnectionResult.Success;

        public void OnDisconnected(DisconnectCause cause)
        {
            _result = NetworkConnectionResult.Fail;
            _logReceiver.Log(new LogData { Message = $"Network disconnected because: {cause}." });
        }

        public void OnConnected()
        {
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }
    }
}