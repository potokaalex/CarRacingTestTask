namespace Client.Code.Game.Gameplay.Car.Controllers.Base
{
    public interface ICarUpdateController : ICarController
    {
        void OnUpdate(float deltaTime);
    }
}