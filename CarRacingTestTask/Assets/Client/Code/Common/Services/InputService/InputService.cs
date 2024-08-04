namespace Client.Code.Common.Services.InputService
{
    public class InputService : IInputService
    {
        private InputObject _input;

        public void Initialize(InputObject input) => _input = input;

        public bool IsMouseOverUI() => _input.EventSystem.IsPointerOverGameObject();
    }
}