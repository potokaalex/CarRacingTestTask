namespace Client.Code.Common.Services.InputService
{
    public class InputService : IInputService
    {
        private InputObject _input;

        public GameInputControls GameControls { get; private set; }

        public void Initialize(InputObject input)
        {
            _input = input;
            GameControls = new GameInputControls();
        }

        public bool IsMouseOverUI() => _input.EventSystem.IsPointerOverGameObject();
    }
}