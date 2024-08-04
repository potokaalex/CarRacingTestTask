using Client.Code.Common.Data.Progress;

namespace Client.Code.Common.Services.Progress.Saver
{
    public interface IProgressWriter
    {
        void OnSave(ProgressData progress);
    }
}