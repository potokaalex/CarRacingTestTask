using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Car;
using Client.Code.Gameplay.GameplaySpawnPoint;
using Client.Code.Services.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace Client.Code.Infrastructure.States
{
    public class GameplayState : IStateAsync
    {
        private readonly CarFactory _carFactory;
        private readonly GameplaySceneData _sceneData;

        public GameplayState(CarFactory carFactory, GameplaySceneData sceneData)
        {
            _carFactory = carFactory;
            _sceneData = sceneData;
        }

        public UniTask Enter()
        {
            _carFactory.Create(_sceneData.CarSpawnPoint.ToSpawnPoint());
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}