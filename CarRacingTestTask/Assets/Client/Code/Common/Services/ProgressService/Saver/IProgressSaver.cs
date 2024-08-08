using Client.Code.Common.Services.ProgressService.Loader;

namespace Client.Code.Common.Services.ProgressService.Saver
{
    public interface IProgressSaver<out T> where T : IProgress
    {
        void Save(bool isPersistence = true);
        void Register(IProgressWriter<T> writer);
        void UnRegister(IProgressWriter<T> writer);
    }
}