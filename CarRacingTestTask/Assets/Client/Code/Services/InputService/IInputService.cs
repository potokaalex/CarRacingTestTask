namespace Client.Code.Services.InputService
{
    public interface IInputService
    {
        void Initialize(InputObject input);
        bool IsMouseOverUI();
    }
}