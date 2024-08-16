using UnityEngine;

namespace Client.Code.Common.Services.CursorService
{
    public class CursorService : ICursorService
    {
        private bool _isLocked;

        public void Set(bool isLocked)
        {
            if (_isLocked == isLocked)
                return;

            _isLocked = isLocked;

            Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isLocked;
        }
    }
}