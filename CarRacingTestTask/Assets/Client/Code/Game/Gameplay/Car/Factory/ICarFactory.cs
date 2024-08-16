using Client.Code.Game.Data;

namespace Client.Code.Game.Gameplay.Car.Factory
{
    public interface ICarFactory
    {
        void Create(SpawnPoint spawnPoint);
        void Destroy();
    }
}