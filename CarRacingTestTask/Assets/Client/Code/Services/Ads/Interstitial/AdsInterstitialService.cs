using Cysharp.Threading.Tasks;
using Zenject;

namespace Client.Code.Services.Ads.Interstitial
{
    public class AdsInterstitialService : IInitializable, IAdsInterstitialService
    {
        private ShowAdResult _showAdResult;
        private LoadAdResult _loadAdResult;

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
            UnityEngine.Debug.Log("Interstitial ad show succeeded."); //TODO: logger
        }

        private void OnAdShowFailed(IronSourceError arg1, IronSourceAdInfo arg2)
        {
            _showAdResult = ShowAdResult.Fail;
            UnityEngine.Debug.Log("Interstitial ad show fail.");
        }

        private void OnAdReady(IronSourceAdInfo obj)
        {
            _loadAdResult = LoadAdResult.Success;
            UnityEngine.Debug.Log("Interstitial ad load success.");
        }

        private void OnAdLoadFailed(IronSourceError obj)
        {
            _loadAdResult = LoadAdResult.Fail;
            UnityEngine.Debug.Log("Interstitial ad load fail.");
        }
    }
}