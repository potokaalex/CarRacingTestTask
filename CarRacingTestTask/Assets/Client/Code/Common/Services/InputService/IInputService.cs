namespace Client.Code.Common.Services.InputService
{
    public interface IInputService
    {
        void Initialize(InputObject input);
        bool IsMouseOverUI();
    }
}