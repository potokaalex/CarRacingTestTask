using UnityEngine;
using Zenject;

namespace Client.Code.Common.UI.Buttons.Load
{
    public class LoadButton : ButtonBase
    {
        [SerializeField] private LoadButtonType _type;
        private ILoadButtonHandler _handler;

        [Inject]
        public void Construct(ILoadButtonHandler handler) => _handler = handler;

        private protected override void OnClick() => _handler.Handle(_type);
    }
}