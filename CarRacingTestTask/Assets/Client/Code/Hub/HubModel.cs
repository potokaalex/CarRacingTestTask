using Client.Code.Data.Progress;
using Client.Code.Gameplay.Car;
using Client.Code.Services.Progress.Loader;
using Client.Code.Services.Progress.Saver;
using Client.Code.UI.Windows;
using UniRx;

namespace Client.Code.Hub
{
    public class HubModel : IProgressReader, IProgressWriter
    {
        public WindowType CurrentWindow = WindowType.None;

        public ReactiveProperty<int> CoinsCount { get; } = new();
        
        public ReactiveProperty<CarColorType> CarColor { get; } = new();

        public ReactiveProperty<bool> IsCarSpoilerPurchased { get; } = new();
        
        public ReactiveProperty<bool> IsCarSpoilerEnabled { get; } = new();
        
        public void OnLoad(ProgressData progress)
        {
            CoinsCount.Value = progress.Player.CoinsCount;
            CarColor.Value = progress.Player.CarColor;
            IsCarSpoilerPurchased.Value = progress.Player.Shop.IsCarSpoilerPurchased;
            IsCarSpoilerEnabled.Value = progress.Player.IsCarSpoilerEnabled;
        }

        public void OnSave(ProgressData progress)
        {
            progress.Player.CoinsCount =  CoinsCount.Value;
            progress.Player.CarColor = CarColor.Value;
            progress.Player.Shop.IsCarSpoilerPurchased = IsCarSpoilerPurchased.Value;
            progress.Player.IsCarSpoilerEnabled = IsCarSpoilerEnabled.Value;
        }
    }
}