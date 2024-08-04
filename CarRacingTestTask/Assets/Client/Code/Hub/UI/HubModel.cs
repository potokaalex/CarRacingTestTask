using System.Collections.Generic;
using Client.Code.Common.Data;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Services.Progress.Loader;
using Client.Code.Common.Services.Progress.Saver;
using Client.Code.Common.Services.Shop.Item;
using Client.Code.Common.UI.Windows;
using UniRx;

namespace Client.Code.Hub.UI
{
    public class HubModel : IProgressReader, IProgressWriter
    {
        public WindowType CurrentWindow = WindowType.None;

        public ReactiveProperty<int> CoinsCount { get; } = new();

        public ReactiveProperty<CarColorType> CarColor { get; } = new();

        public ReactiveProperty<bool> IsCarSpoilerEnabled { get; } = new();

        public ReactiveProperty<bool> IsMasterAudioEnabled { get; } = new();

        public ReactiveCollection<ShopItemType> PurchasedItems { get; } = new();

        public void OnLoad(ProgressData progress)
        {
            CoinsCount.Value = progress.Player.CoinsCount;
            CarColor.Value = progress.Player.CarColor;
            IsCarSpoilerEnabled.Value = progress.Player.IsCarSpoilerEnabled;
            IsMasterAudioEnabled.Value = progress.Project.IsMasterAudioEnabled;

            foreach (var item in progress.Player.Shop.PurchasedItems)
                PurchasedItems.Add(item);
        }

        public void OnSave(ProgressData progress)
        {
            progress.Player.CoinsCount = CoinsCount.Value;
            progress.Player.CarColor = CarColor.Value;
            progress.Player.IsCarSpoilerEnabled = IsCarSpoilerEnabled.Value;
            progress.Project.IsMasterAudioEnabled = IsMasterAudioEnabled.Value;
            progress.Player.Shop.PurchasedItems = new List<ShopItemType>(PurchasedItems);
        }
    }
}