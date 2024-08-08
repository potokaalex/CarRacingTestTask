using Client.Code.Common.Services.ProgressService.Loader;

namespace Client.Code.Common.Services.ProgressService.Saver
{
    public interface IProgressWriter<in T> where T : IProgress
    {
        void OnSave(T progress);
    }
}