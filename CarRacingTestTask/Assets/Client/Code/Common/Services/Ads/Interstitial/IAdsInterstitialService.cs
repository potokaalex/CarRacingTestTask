using Cysharp.Threading.Tasks;

namespace Client.Code.Common.Services.Ads.Interstitial
{
    public interface IAdsInterstitialService
    {
        UniTask<ShowAdResult> ShowAsync();
    }
}