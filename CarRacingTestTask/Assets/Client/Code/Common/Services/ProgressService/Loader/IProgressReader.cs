using Client.Code.Common.Data.Progress;

namespace Client.Code.Common.Services.ProgressService.Loader
{
    public interface IProgressReader<in T> where T : IProgress
    {
        void OnLoad(T progress);
    }
}