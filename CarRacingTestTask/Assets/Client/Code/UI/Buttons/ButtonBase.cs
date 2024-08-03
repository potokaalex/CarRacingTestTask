using UnityEngine;
using UnityEngine.UI;

namespace Client.Code.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonBase : MonoBehaviour
    {
        private Button _baseButton;

        public void Lock(bool isLocked)
        {
            _baseButton.image.color = isLocked ? Color.black : Color.white;
            _baseButton.interactable = !isLocked;
        }

        private void Awake()
        {
            _baseButton = gameObject.GetComponent<Button>();
            _baseButton.onClick.AddListener(OnClick);
        }

        private void OnDestroy() => _baseButton.onClick.RemoveListener(OnClick);

        private protected abstract void OnClick();
    }
}