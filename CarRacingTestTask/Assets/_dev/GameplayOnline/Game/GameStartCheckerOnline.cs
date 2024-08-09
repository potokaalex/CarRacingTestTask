using Client._dev.GameplayOnline.Infrastructure.States;
using Client.Code.Common.Services.StateMachine;
using Photon.Pun;

namespace Client._dev.GameplayOnline.Game
{
    public class GameStartCheckerOnline
    {
        private readonly IStateMachine _stateMachine;

        public GameStartCheckerOnline(IStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Check()
        {
            if (PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
                _stateMachine.SwitchTo<GameplayOnlineState>();
        }
    }
}