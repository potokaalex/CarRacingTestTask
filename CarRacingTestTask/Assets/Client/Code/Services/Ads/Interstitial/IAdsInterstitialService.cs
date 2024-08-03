using System;
using Cysharp.Threading.Tasks;

namespace Client.Code.Services.Ads.Interstitial
{
    public interface IAdsInterstitialService
    {
        UniTask<ShowAdResult> ShowAsync();
    }
}