namespace Client.Code.Common.Services.InputService
{
    public interface IInputService
    {
        GameInputControls GameControls { get; }
        void Initialize(InputObject input);
        bool IsMouseOverUI();
    }
}