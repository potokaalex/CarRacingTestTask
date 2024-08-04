using ExitGames.Client.Photon;

namespace Client.Code.GameplayOnline.Game.Car
{
    public interface INetworkEventReceiver
    {
        void Receive(EventData data);
    }
}