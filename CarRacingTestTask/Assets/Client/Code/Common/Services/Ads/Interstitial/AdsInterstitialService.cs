using Client.Code.Common.Services.Logger.Base;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Client.Code.Common.Services.Ads.Interstitial
{
    public class AdsInterstitialService : IInitializable, IAdsInterstitialService
    {
        private readonly ILogReceiver _logReceiver;
        private ShowAdResult _showAdResult;
        private LoadAdResult _loadAdResult;

        public AdsInterstitialService(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public void Initialize()
        {
            IronSourceInterstitialEvents.onAdReadyEvent += OnAdReady;
            IronSourceInterstitialEvents.onAdLoadFailedEvent += OnAdLoadFailed;

            IronSourceInterstitialEvents.onAdShowSucceededEvent += OnAdShowSucceeded;
            IronSourceInterstitialEvents.onAdShowFailedEvent += OnAdShowFailed;
        }

        public async UniTask<ShowAdResult> ShowAsync()
        {
            var result = await LoadAsync();

            if (result == LoadAdResult.Fail)
                return ShowAdResult.Fail;

            _showAdResult = ShowAdResult.None;

            IronSource.Agent.showInterstitial();
            await UniTask.WaitUntil(() => _showAdResult != ShowAdResult.None);
            return _showAdResult;
        }

        private async UniTask<LoadAdResult> LoadAsync()
        {
            _loadAdResult = LoadAdResult.None;
            IronSource.Agent.loadInterstitial();

            await UniTask.WaitUntil(() => _loadAdResult != LoadAdResult.None);
            return _loadAdResult;
        }

        private void OnAdShowSucceeded(IronSourceAdInfo obj)
        {
            _showAdResult = ShowAdResult.Success;
            _logReceiver.Log(new LogData { Message = "Interstitial ad show succeeded." });
        }

        private void OnAdShowFailed(IronSourceError arg1, IronSourceAdInfo arg2)
        {
            _showAdResult = ShowAdResult.Fail;
            _logReceiver.Log(new LogData { Message = "Interstitial ad show fail." });
        }

        private void OnAdReady(IronSourceAdInfo obj)
        {
            _loadAdResult = LoadAdResult.Success;
            _logReceiver.Log(new LogData { Message = "Interstitial ad load success." });
        }

        private void OnAdLoadFailed(IronSourceError obj)
        {
            _loadAdResult = LoadAdResult.Fail;
            _logReceiver.Log(new LogData { Message = "Interstitial ad load fail." });
        }
    }
}