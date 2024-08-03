using UnityEngine;
using Zenject;

namespace Client.Code.UI.Buttons.Exit
{
    public class ExitButton : ButtonBase
    {
        [SerializeField] private ExitButtonType _type;
        private IExitButtonHandler _handler;

        [Inject]
        public void Construct(IExitButtonHandler handler) => _handler = handler;

        private protected override void OnClick() => _handler.Handle(_type);
    }
}