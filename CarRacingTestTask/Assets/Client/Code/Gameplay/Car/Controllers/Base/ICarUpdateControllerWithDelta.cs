namespace Client.Code.Gameplay.Car.Controllers.Base
{
    public interface ICarUpdateControllerWithDelta : ICarController
    {
        void OnUpdate(float deltaTime);
    }
}