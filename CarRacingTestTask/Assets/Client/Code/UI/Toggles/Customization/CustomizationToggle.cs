using UnityEngine;
using Zenject;

namespace Client.Code.UI.Toggles.Customization
{
    public class CustomizationToggle : ToggleBase
    {
        [SerializeField] private CustomizationToggleType _type;
        private ICustomizationToggleHandler _handler;
        
        [Inject]
        public void Construct(ICustomizationToggleHandler handler) => _handler = handler;
        
        private protected override void OnToggleValueChanged(bool isActive) => _handler.Handle(_type, isActive);
    }
}