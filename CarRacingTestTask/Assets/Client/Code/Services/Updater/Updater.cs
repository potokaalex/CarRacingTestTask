using System;
using UnityEngine;

namespace Client.Code.Services.Updater
{
    public class Updater : MonoBehaviour, IUpdater
    {
        public event Action OnUpdate;
        public event Action OnFixedUpdate;
        public event Action<float> OnFixedUpdateWithDelta;
        public event Action OnProjectExit;

        private void Update() => OnUpdate?.Invoke();

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
            OnFixedUpdateWithDelta?.Invoke(Time.fixedDeltaTime);
        }

        private void OnDestroy() => OnProjectExit?.Invoke();

        public void ClearAllListeners()
        {
            OnUpdate = null;
            OnFixedUpdate = null;
            OnProjectExit = null;
        }
    }
}