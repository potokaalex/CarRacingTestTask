using Client.Code.Common.Data.Progress;

namespace Client.Code.Common.Services.ProgressService.Saver
{
    public interface IProgressWriter
    {
        void OnSave(ProgressData progress);
    }
}