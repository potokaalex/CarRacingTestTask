using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.Code.UI.Buttons.DoubleCoins
{
    public class DoubleCoinsButton : ButtonBase
    {
        [SerializeField] private Image _buttonImage;
        private IDoubleCoinsButtonHandler _handler;
        private bool _isLocked;

        [Inject]
        public void Construct(IDoubleCoinsButtonHandler handler) => _handler = handler;

        public void Lock()
        {
            _isLocked = true;
            _buttonImage.color = Color.black;
        }

        private protected override void OnClick()
        {
            if (!_isLocked)
                _handler.Handle();
        }
    }
}