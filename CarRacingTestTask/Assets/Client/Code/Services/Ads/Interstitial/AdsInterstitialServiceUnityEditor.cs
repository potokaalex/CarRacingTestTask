using Cysharp.Threading.Tasks;

namespace Client.Code.Services.Ads.Interstitial
{
    public class AdsInterstitialServiceUnityEditor : IAdsInterstitialService
    {
        public UniTask<ShowAdResult> ShowAsync() => new(ShowAdResult.Success);
    }
}