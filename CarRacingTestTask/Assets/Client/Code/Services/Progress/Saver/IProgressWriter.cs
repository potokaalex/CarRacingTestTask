using Client.Code.Data.Progress;

namespace Client.Code.Services.Progress.Saver
{
    public interface IProgressWriter
    {
        void OnSave(ProgressData progress);
    }
}