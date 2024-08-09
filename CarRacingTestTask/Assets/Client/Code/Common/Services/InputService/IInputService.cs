namespace Client.Code.Common.Services.InputService
{
    public interface IInputService
    {
        InputControls Controls { get; }
        void Initialize(InputObject input);
        bool IsMouseOverUI();
    }
}