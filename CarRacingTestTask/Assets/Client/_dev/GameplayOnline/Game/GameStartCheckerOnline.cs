using Client.Code.Common.Services.StateMachine;
using Client.Code.GameplayOnline.Infrastructure.States;
using Photon.Pun;

namespace Client.Code.GameplayOnline.Game
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