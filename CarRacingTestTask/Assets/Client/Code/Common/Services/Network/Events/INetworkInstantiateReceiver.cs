using Photon.Pun;

namespace Client.Code.Common.Services.Network.Events
{
    public interface INetworkInstantiateReceiver
    {
        void Receive(PhotonMessageInfo data);
    }
}