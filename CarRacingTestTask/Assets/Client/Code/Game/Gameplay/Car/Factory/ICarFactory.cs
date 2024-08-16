using Client.Code.Game.Data.GameSpawnPoint;

namespace Client.Code.Game.Gameplay.Car.Factory
{
    public interface ICarFactory
    {
        void Create(SpawnPoint spawnPoint);
        void Destroy();
    }
}