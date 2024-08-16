using Client.Code.Common.Services.CursorService;

namespace Client.Code.Game.Services.Pause
{
    public class GamePauseService
    {
        private readonly ICursorService _cursor;
        public bool IsPaused { get; private set; }

        public GamePauseService(ICursorService cursor) => _cursor = cursor;

        public void Enable()
        {
            IsPaused = true;
            _cursor.Set(false);
        }

        public void Disable()
        {
            IsPaused = false;
            _cursor.Set(true);
        }

        /*
             public void Set(bool isLocked)
    {
        if (_isLocked == isLocked)
            return;

        _isLocked = isLocked;

        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isLocked;
    }
         */
    }
}