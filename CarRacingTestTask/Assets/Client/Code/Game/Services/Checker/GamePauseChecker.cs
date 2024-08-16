using Client.Code.Common.Services.InputService;
using UnityEngine.InputSystem;

namespace Client.Code.Game.Services.Checker
{
    public class GamePauseChecker
    {
        private readonly IInputService _inputService;
        private GameControls.PauseActions _pause;
        private bool _isPaused;

        public GamePauseChecker(IInputService inputService) => _inputService = inputService;

        public void Initialize()
        {
            _pause = _inputService.GameControls.Pause;
            _pause.EnablePause.performed += EnablePause;
            _pause.DisablePause.performed += DisablePause;
            _pause.Enable();
        }

        public void Dispose()
        {
            _pause.EnablePause.performed -= EnablePause;
            _pause.DisablePause.performed -= DisablePause;
            _pause.Disable();
        }

        private void EnablePause(InputAction.CallbackContext context)
        {
            if(_isPaused)
                return;
            
            _isPaused = true;
            UnityEngine.Debug.Log("Unlock cursor");
            //unlock cursor.
        }

        private void DisablePause(InputAction.CallbackContext context)
        {
            if(!_isPaused || _inputService.IsMouseOverUI())
                return;
            
            _isPaused = false;
            UnityEngine.Debug.Log("Lock cursor");
            //lock cursor.
        }
    }
}