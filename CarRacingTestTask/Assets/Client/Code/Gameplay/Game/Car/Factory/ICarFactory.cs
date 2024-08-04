using Client.Code.Gameplay.Game.GameSpawnPoint;

namespace Client.Code.Gameplay.Game.Car.Factory
{
    public interface ICarFactory
    {
        void Create(SpawnPoint spawnPoint);
        void Destroy();
    }
}