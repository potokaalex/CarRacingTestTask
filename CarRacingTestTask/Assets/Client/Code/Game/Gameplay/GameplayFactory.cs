using Client.Code.Game.Data;
using Client.Code.Game.Gameplay.Car.Factory;
using Client.Code.Game.Gameplay.GameplayCamera.Factory;
using Client.Code.Game.Gameplay.Player;
using Client.Code.Game.Services.Extensions;

namespace Client.Code.Game.Gameplay
{
    public class GameplayFactory
    {
        private readonly GameSceneData _sceneData;
        private readonly ICarFactory _carFactory;
        private readonly ICameraFactory _cameraFactory;
        private readonly PlayerFactory _playerFactory;

        public GameplayFactory(GameSceneData sceneData, ICarFactory carFactory, ICameraFactory cameraFactory, PlayerFactory playerFactory)
        {
            _sceneData = sceneData;
            _carFactory = carFactory;
            _cameraFactory = cameraFactory;
            _playerFactory = playerFactory;
        }

        public void Create()
        {
            _carFactory.Create(_sceneData.CarSpawnPoint.ToSpawnPoint());
            _cameraFactory.Create();
            _playerFactory.Create();
        }

        public void Destroy()
        {
            _carFactory.Destroy();
            _cameraFactory.Destroy();
            _playerFactory.Destroy();
        }
    }
}