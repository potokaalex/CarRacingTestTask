using Client.Code.Common.Data.Static.Configs.Project;
using Client.Code.Common.Services.SceneLoader;
using Client.Code.Common.Services.StateMachine.Global;
using Client.Code.Common.Services.StateMachine.State;
using Cysharp.Threading.Tasks;
using ExitGames.Client.Photon;

namespace Client.Code.Common.Infrastructure.States
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
            var connectionResult = await _networkConnectionService.ConnectToMasterAsync();

            if (connectionResult == NetworkConnectionResult.Fail)
                _stateMachine.SwitchTo<HubStateGlobal>();

            var joinRoomResult = await _networkRoomService.JoinRoomAsync();

            if (joinRoomResult == NetworkJoinRoomResult.Fail)
                _stateMachine.SwitchTo<HubStateGlobal>();

            _sceneLoader.LoadSceneAsync(SceneName.GameplayOnline);
            
            UnityEngine.Debug.Log("Connection ready !");
            
            //load scene ?
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}