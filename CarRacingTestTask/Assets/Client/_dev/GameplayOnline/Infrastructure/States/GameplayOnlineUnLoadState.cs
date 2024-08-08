using Client.Code.Common.Services.StateMachine.State;
using Photon.Pun;

namespace Client.Code.GameplayOnline.Infrastructure.States
{
    public class GameplayOnlineUnLoadState : IState
    {
        public void Enter() => PhotonNetwork.LeaveRoom();

        public void Exit()
        {
        }
    }
}