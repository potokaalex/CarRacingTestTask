using UnityEngine;
using Zenject;

namespace Client.Code.UI.Buttons.Exit
{
    public class ExitButton : ButtonBase
    {
        private IExitButtonHandler _handler;

        [Inject]
        public void Construct(IExitButtonHandler handler) => _handler = handler;

        private protected override void OnClick() => _handler.Handle();
    }
}