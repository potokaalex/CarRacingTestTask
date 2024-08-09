using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Client.Code.Common.UI.Dropdowns
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public abstract class DropdownBase : SerializedMonoBehaviour
    {
        private protected TMP_Dropdown BaseDropdown;

        private protected virtual void Awake()
        {
            BaseDropdown = GetComponent<TMP_Dropdown>();
            BaseDropdown.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnEnable() => BaseDropdown.onValueChanged.AddListener(OnValueChanged);

        private void OnDisable() => BaseDropdown.onValueChanged.RemoveListener(OnValueChanged);

        private protected abstract void OnValueChanged(int elementNumber);
    }
}