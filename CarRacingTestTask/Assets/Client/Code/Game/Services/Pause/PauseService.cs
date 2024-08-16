using Client.Code.Common.Services.CursorService;

namespace Client.Code.Game.Services.Pause
{
    public class PauseService
    {
        private readonly ICursorService _cursor;
        public bool IsPaused { get; private set; }

        public PauseService(ICursorService cursor) => _cursor = cursor;

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
    }
}