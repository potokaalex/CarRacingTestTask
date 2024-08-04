using Client.Code.Common.Data.Progress;

namespace Client.Code.Common.Services.Progress.Loader
{
    public interface IProgressReader
    {
        void OnLoad(ProgressData progress);
    }
}