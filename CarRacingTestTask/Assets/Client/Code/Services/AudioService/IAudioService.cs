namespace Client.Code.AudioManagerService
{
    public interface IAudioService
    {
        void Initialize();
        void SetMasterActive(bool isActive);
    }
}