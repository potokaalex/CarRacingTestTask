using Client.Code.Common.Services.StateMachine;
using Client.Code.GameplayOnline.Game.Car;
using Client.Code.GameplayOnline.Infrastructure.States;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using Zenject;

namespace Client.Code.GameplayOnline.Game
{
    public class GameStartCheckerOnline
    {
        private readonly IStateMachine _stateMachine;

        public GameStartCheckerOnline(IStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Check()
        {
            if (PhotonNetwork.InRoom &&  PhotonNetwork.CurrentRoom.PlayerCount >= 2) 
                _stateMachine.SwitchTo<GameplayOnlineState>();
        }
    }
}