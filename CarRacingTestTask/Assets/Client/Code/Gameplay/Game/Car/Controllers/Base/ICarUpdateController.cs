namespace Client.Code.Gameplay.Game.Car.Controllers.Base
{
    public interface ICarUpdateController : ICarController
    {
        void OnUpdate(float deltaTime);
    }
}