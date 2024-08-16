namespace Client.Code.Common.Services.InputService
{
    public class InputService : IInputService
    {
        private InputObject _input;

        public GameplayInputControls GameplayControls { get; private set; }

        public void Initialize(InputObject input)
        {
            _input = input;
            GameplayControls = new GameplayInputControls();
        }

        public bool IsMouseOverUI() => _input.EventSystem.IsPointerOverGameObject();
    }
}