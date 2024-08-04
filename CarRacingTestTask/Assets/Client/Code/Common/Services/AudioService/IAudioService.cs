namespace Client.Code.Common.Services.AudioService
{
    public interface IAudioService
    {
        void Initialize();
        void SetMasterActive(bool isActive);
    }
}