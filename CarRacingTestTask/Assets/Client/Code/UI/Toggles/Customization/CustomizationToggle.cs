using UnityEngine;
using Zenject;

namespace Client.Code.UI.Toggles
{
    public class CustomizationToggle : ToggleBase
    {
        [SerializeField] private CustomizationToggleType _type;
        private ICustomizationToggleHandler _handler;
        
        [Inject]
        public void Construct(ICustomizationToggleHandler handler) => _handler = handler;

        public void Set(bool isActive) => BaseToggle.SetIsOnWithoutNotify(isActive);

        public void Lock(bool isLocked) => BaseToggle.interactable = !isLocked;
        
        private protected override void OnToggleValueChanged(bool isActive) => _handler.Handle(_type, isActive);
    }
}