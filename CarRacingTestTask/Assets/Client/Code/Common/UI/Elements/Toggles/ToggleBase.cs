using UnityEngine;
using UnityEngine.UI;

namespace Client.Code.Common.UI.Elements.Toggles
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ToggleBase : MonoBehaviour
    {
        private Toggle _baseToggle;

        public void SetWithoutNotify(bool isActive) => _baseToggle.SetIsOnWithoutNotify(isActive);

        public void Lock(bool isLocked) => _baseToggle.interactable = !isLocked;

        private void Awake() => _baseToggle = GetComponent<Toggle>();

        private void OnEnable() => _baseToggle.onValueChanged.AddListener(OnToggleValueChanged);

        private void OnDisable() => _baseToggle.onValueChanged.RemoveListener(OnToggleValueChanged);

        private protected abstract void OnToggleValueChanged(bool isActive);
    }
}