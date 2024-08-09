using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.Code.Common.UI.Buttons.DoubleCoins
{
    public class DoubleCoinsButton : ButtonBase
    {
        [SerializeField] private Image _buttonImage;
        private IDoubleCoinsButtonHandler _handler;

        [Inject]
        public void Construct(IDoubleCoinsButtonHandler handler) => _handler = handler;

        private protected override void OnClick() => _handler.Handle();
    }
}