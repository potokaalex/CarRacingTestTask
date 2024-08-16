using Client._dev.GameplayOnline.Data;
using Client.Code.Common.Services.StateMachine.State;
using Client.Code.Game.Gameplay.Car.Factory;
using Client.Code.Game.Gameplay.GameCamera.Factory;
using Client.Code.Game.Services.Extensions;

namespace Client._dev.GameplayOnline.Infrastructure.States
{
    public class GameplayOnlineState : IState
    {
        private readonly ICameraFactory _cameraFactory;
        private readonly ICarFactory _carFactory;
        private readonly GameplayOnlineSceneData _sceneData;

        public GameplayOnlineState(ICameraFactory cameraFactory, ICarFactory carFactory, GameplayOnlineSceneData sceneData)
        {
            _cameraFactory = cameraFactory;
            _carFactory = carFactory;
            _sceneData = sceneData;
        }

        public void Enter()
        {
            _carFactory.Create(_sceneData.CarsSpawnPoint.ToSpawnPoint());
            _cameraFactory.Create();
        }

        public void Exit()
        {
            _carFactory.Destroy();
            _cameraFactory.Destroy();
        }
    }
}