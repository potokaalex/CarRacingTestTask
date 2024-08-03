using Client.Code.Data.Progress;

namespace Client.Code.Services.Progress.Loader
{
    public interface IProgressReader
    {
        void OnLoad(ProgressData progress);
    }
}