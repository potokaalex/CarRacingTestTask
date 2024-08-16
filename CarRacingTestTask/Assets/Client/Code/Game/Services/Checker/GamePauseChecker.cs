using Client.Code.Common.Services.InputService;
using Client.Code.Game.Services.Pause;
using UnityEngine.InputSystem;

namespace Client.Code.Game.Services.Checker
{
    public class GamePauseChecker
    {
        private readonly IInputService _inputService;
        private readonly GamePauseService _pause;
        private GameControls.PauseActions _actions;

        public GamePauseChecker(IInputService inputService, GamePauseService pause)
        {
            _inputService = inputService;
            _pause = pause;
        }

        public void Initialize()
        {
            _actions = _inputService.GameControls.Pause;
            _actions.EnablePause.performed += EnablePause;
            _actions.DisablePause.performed += DisablePause;
            _actions.Enable();
        }

        public void Dispose()
        {
            _actions.EnablePause.performed -= EnablePause;
            _actions.DisablePause.performed -= DisablePause;
            _actions.Disable();
        }

        private void EnablePause(InputAction.CallbackContext context)
        {
            if(!_pause.IsPaused)
                _pause.Enable();
        }

        private void DisablePause(InputAction.CallbackContext context)
        {
            if(_pause.IsPaused && !_inputService.IsMouseOverUI())
                _pause.Disable();
        }
    }
}