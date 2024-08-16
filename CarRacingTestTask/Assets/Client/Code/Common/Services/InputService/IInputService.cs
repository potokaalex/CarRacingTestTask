namespace Client.Code.Common.Services.InputService
{
    public interface IInputService
    {
        GameplayInputControls GameplayControls { get; }
        void Initialize(InputObject input);
        bool IsMouseOverUI();
    }
}