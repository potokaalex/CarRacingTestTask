using Client.Code.Common.Data;
using Client.Code.Common.Infrastructure.States;
using Client.Code.Common.Services.Network.Connection;
using Client.Code.Common.Services.Network.Room;
using Client.Code.Common.Services.SceneLoader;
using Client.Code.Common.Services.SceneLoader.Data;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.Services.StateMachine.State;
using Cysharp.Threading.Tasks;
using Photon.Pun;

namespace Client._dev
{
    public class GameplayOnlineStateGlobal : IStateAsync
    {
        private readonly INetworkConnectionService _networkConnectionService;
        private readonly IGlobalStateMachine _stateMachine;
        private readonly INetworkRoomService _networkRoomService;
        private readonly ISceneLoader _sceneLoader;

        public GameplayOnlineStateGlobal(INetworkConnectionService networkConnectionService, IGlobalStateMachine stateMachine,
            INetworkRoomService networkRoomService, ISceneLoader sceneLoader)
        {
            _networkConnectionService = networkConnectionService;
            _stateMachine = stateMachine;
            _networkRoomService = networkRoomService;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            if (!PhotonNetwork.IsConnected)
            {
                var connectionResult = await _networkConnectionService.ConnectToMasterAsync();
                if (connectionResult == NetworkConnectionResult.Fail)
                    _stateMachine.SwitchTo<HubStateGlobal>();
            }

            await _sceneLoader.LoadSceneAsync(SceneName.GameOnline);

            var joinRoomResult = await _networkRoomService.JoinRoomAsync();
            if (joinRoomResult == NetworkJoinRoomResult.Fail)
                _stateMachine.SwitchTo<HubStateGlobal>();
        }
    }
}