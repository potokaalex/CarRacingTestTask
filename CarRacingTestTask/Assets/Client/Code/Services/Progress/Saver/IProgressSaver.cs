namespace Client.Code.Services.Progress.Saver
{
    public interface IProgressSaver
    {
        void Save();
        void Register(IProgressWriter writer);
        void UnRegister(IProgressWriter writer);
    }
}