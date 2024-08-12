using UnityEngine;

namespace Client.Code.Gameplay.Game.GameCamera
{
    public class CursorController
    {
        private bool _isLocked;
        
        public void Initialize() => Set(true);
        
        public void Dispose() => Set(false);

        public void Set(bool isLocked)
        {
            if(_isLocked == isLocked)
                return;
            _isLocked = isLocked;

            Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isLocked;
        }
        
        /*
        private void UpdateCursor(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            var isNotLocked = Mathf.Approximately(value, 0);

            if (isNotLocked)
                _cursorController.Set(false);
            else if (!EventSystem.current.IsPointerOverGameObject())
                _cursorController.Set(true);
        }
        */
    }
}