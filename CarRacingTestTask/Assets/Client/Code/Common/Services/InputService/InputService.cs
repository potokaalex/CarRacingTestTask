using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Client.Code.Common.Services.InputService
{
    public class InputService : IInputService
    {
        private readonly List<RaycastResult> _raycastResultsBuffer = new();
        
        public GameControls GameControls { get; private set; }
        
        public GameplayInputControls GameplayControls { get; private set; }

        public void Initialize()
        {
            GameControls = new GameControls();
            GameplayControls = new GameplayInputControls();
        }

        public bool IsMouseOverUI()
        {
            var position = Mouse.current.position.ReadValue();
            var eventData = new PointerEventData(EventSystem.current)
            {
                position = position
            };

            EventSystem.current.RaycastAll(eventData, _raycastResultsBuffer);

            return _raycastResultsBuffer.Count > 0;
        }
    }
}