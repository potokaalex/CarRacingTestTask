using UnityEngine;
using UnityEngine.UI;

namespace Client.Code.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonBase : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy() => _button.onClick.RemoveListener(OnClick);

        private protected abstract void OnClick();
    }
}