using System.Collections.Generic;
using Client.Code.Common.Data;
using Client.Code.Common.Data.Progress;
using Client.Code.Common.Data.Progress.Player;
using Client.Code.Common.Services.ProgressService.Loader;
using Client.Code.Common.Services.ProgressService.Saver;
using Client.Code.Common.Services.Shop.Data.Item;
using Client.Code.Common.UI.Elements.Windows;
using UniRx;

namespace Client.Code.Hub.UI
{
    public class HubModel : IProgressReader<ProjectProgress>, IProgressWriter<ProjectProgress>, IProgressReader<PlayerProgress>,
        IProgressWriter<PlayerProgress>
    {
        public WindowType CurrentWindow = WindowType.None;

        public ReactiveProperty<int> CoinsCount { get; } = new();

        public ReactiveProperty<CarColorType> CarColor { get; } = new();

        public ReactiveProperty<bool> IsCarSpoilerEnabled { get; } = new();

        public ReactiveProperty<bool> IsMasterAudioEnabled { get; } = new();

        public ReactiveCollection<ShopItemType> PurchasedItems { get; } = new();

        public void OnLoad(ProjectProgress progress) => IsMasterAudioEnabled.Value = progress.IsMasterAudioEnabled;

        public void OnSave(ProjectProgress progress) => progress.IsMasterAudioEnabled = IsMasterAudioEnabled.Value;

        public void OnLoad(PlayerProgress progress)
        {
            CoinsCount.Value = progress.CoinsCount;
            CarColor.Value = progress.CarColor;
            IsCarSpoilerEnabled.Value = progress.IsCarSpoilerEnabled;

            foreach (var item in progress.Shop.PurchasedItems)
                PurchasedItems.Add(item);
        }

        public void OnSave(PlayerProgress progress)
        {
            progress.CoinsCount = CoinsCount.Value;
            progress.CarColor = CarColor.Value;
            progress.IsCarSpoilerEnabled = IsCarSpoilerEnabled.Value;
            progress.Shop.PurchasedItems = new List<ShopItemType>(PurchasedItems);
        }
    }
}