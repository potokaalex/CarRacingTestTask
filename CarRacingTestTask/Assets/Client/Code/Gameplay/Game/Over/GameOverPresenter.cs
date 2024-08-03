using Client.Code.Gameplay.Player;
using Client.Code.Services.Ads;
using Client.Code.Services.Ads.Interstitial;
using Client.Code.UI.Buttons.DoubleCoins;
using Cysharp.Threading.Tasks;

namespace Client.Code.Gameplay.Game.Over
{
    public class GameOverPresenter : IDoubleCoinsButtonHandler
    {
        private readonly IAdsInterstitialService _adsInterstitialService;
        private readonly PlayerCoinsController _playerCoinsController;
        private GameOverScreen _screen;

        public GameOverPresenter(IAdsInterstitialService adsInterstitialService, PlayerCoinsController playerCoinsController)
        {
            _adsInterstitialService = adsInterstitialService;
            _playerCoinsController = playerCoinsController;
        }

        public void Initialize(GameOverScreen screen) => _screen = screen;

        public void Handle() => HandleDoubleCoinsButtonAsync().Forget();

        private async UniTaskVoid HandleDoubleCoinsButtonAsync()
        {
            var result = await _adsInterstitialService.ShowAsync();

            if (result != ShowAdResult.Success)
                return;

            _playerCoinsController.DoubleSessionsCoins();
            _screen.CoinsView.SetCoinsCount(_playerCoinsController.SessionCoinsCount);
            _screen.DoubleCoinsButton.Lock();
        }
    }
}