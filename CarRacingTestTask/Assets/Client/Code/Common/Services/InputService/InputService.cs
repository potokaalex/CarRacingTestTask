namespace Client.Code.Common.Services.InputService
{
    public class InputService : IInputService
    {
        private InputObject _input;

        public InputControls Controls { get; private set; }

        public void Initialize(InputObject input)
        {
            _input = input;
            Controls = new InputControls();
        }

        public bool IsMouseOverUI() => _input.EventSystem.IsPointerOverGameObject();
    }
}