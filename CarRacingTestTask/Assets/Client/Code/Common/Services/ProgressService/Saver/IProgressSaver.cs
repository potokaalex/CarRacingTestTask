namespace Client.Code.Common.Services.ProgressService.Saver
{
    public interface IProgressSaver
    {
        void Save();
        void Register(IProgressWriter writer);
        void UnRegister(IProgressWriter writer);
    }
}