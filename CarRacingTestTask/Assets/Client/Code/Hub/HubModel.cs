using Client.Code.Data.Progress;
using Client.Code.Services.Progress.Loader;
using Client.Code.UI.Windows;
using UniRx;

namespace Client.Code.Hub
{
    public class HubModel : IProgressReader
    {
        public WindowType CurrentWindow = WindowType.None;

        public ReactiveProperty<int> CoinsCount { get; private set; } = new();

        public void OnLoad(ProgressData progress) => CoinsCount.Value = progress.Player.CoinsCount;
    }
}