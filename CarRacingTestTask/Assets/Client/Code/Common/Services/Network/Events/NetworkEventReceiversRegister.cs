using System;
using System.Collections.Generic;
using Photon.Pun;
using Zenject;

namespace Client.Code.Common.Services.Network.Events
{
    public class NetworkEventReceiversRegister : IInitializable, IDisposable, IPunInstantiateMagicCallback
    {
        private readonly List<INetworkInstantiateReceiver> _receivers;

        public NetworkEventReceiversRegister(List<INetworkInstantiateReceiver> receivers) => _receivers = receivers;

        public void Initialize() => PhotonNetwork.AddCallbackTarget(this);

        public void Dispose() => PhotonNetwork.RemoveCallbackTarget(this);

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            foreach (var receiver in _receivers)
                receiver.Receive(info);
        }
    }
}