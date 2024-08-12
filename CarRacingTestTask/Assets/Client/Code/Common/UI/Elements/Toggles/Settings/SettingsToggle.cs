using UnityEngine;
using Zenject;

namespace Client.Code.Common.UI.Elements.Toggles.Settings
{
    public class SettingsToggle : ToggleBase
    {
        [SerializeField] private SettingsToggleType _type;
        private ISettingsToggleHandler _handler;

        [Inject]
        public void Construct(ISettingsToggleHandler handler) => _handler = handler;

        private protected override void OnToggleValueChanged(bool isActive) => _handler.Handle(_type, isActive);
    }
}