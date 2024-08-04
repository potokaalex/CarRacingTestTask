using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using Zenject;

namespace Client.Code.GameplayOnline.Game.Car
{
    public class NetworkEventReceiversRegister : IInitializable, IDisposable, IOnEventCallback
    {
        private readonly List<INetworkEventReceiver> _receivers;

        public NetworkEventReceiversRegister(List<INetworkEventReceiver> receivers) => _receivers = receivers;

        public void Initialize() => PhotonNetwork.AddCallbackTarget(this);

        public void Dispose() => PhotonNetwork.RemoveCallbackTarget(this);

        public void OnEvent(EventData photonEvent)
        {
            foreach(var receiver in _receivers)
                receiver.Receive(photonEvent);
        }
    }
}