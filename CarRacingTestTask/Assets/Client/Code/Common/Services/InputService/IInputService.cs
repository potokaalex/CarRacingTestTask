namespace Client.Code.Common.Services.InputService
{
    public interface IInputService
    {
        GameControls GameControls { get; }
        GameplayInputControls GameplayControls { get; }
        void Initialize();
        bool IsMouseOverUI();
    }
}