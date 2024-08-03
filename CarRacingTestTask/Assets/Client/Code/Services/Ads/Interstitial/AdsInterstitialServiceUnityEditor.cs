using Client.Code.Services.Logger.Base;
using Cysharp.Threading.Tasks;

namespace Client.Code.Services.Ads.Interstitial
{
    public class AdsInterstitialServiceUnityEditor : IAdsInterstitialService
    {
        private readonly ILogReceiver _logReceiver;

        public AdsInterstitialServiceUnityEditor(ILogReceiver logReceiver) => _logReceiver = logReceiver;

        public UniTask<ShowAdResult> ShowAsync()
        {
            _logReceiver.Log(new LogData {Message = "Interstitial ad show succeeded."});
            return new UniTask<ShowAdResult>(ShowAdResult.Success);
        }
    }
}