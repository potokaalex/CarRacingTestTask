using UnityEngine;
using UnityEngine.UI;

namespace Client.Code.UI.Toggles
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ToggleBase : MonoBehaviour
    {
        private protected Toggle BaseToggle;

        private void Awake() => BaseToggle = GetComponent<Toggle>();

        private void OnEnable() => BaseToggle.onValueChanged.AddListener(OnToggleValueChanged);

        private void OnDisable() => BaseToggle.onValueChanged.RemoveListener(OnToggleValueChanged);

        private protected abstract void OnToggleValueChanged(bool isActive);
    }
}