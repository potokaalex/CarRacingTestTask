namespace Client.Code.Gameplay.Car.Controllers.Base
{
    public interface ICarUpdateController : ICarController
    {
        void OnUpdate(float deltaTime);
    }
}