using System;
using UnityEngine;

namespace Client.Code.Services.Updater
{
    public class Updater : MonoBehaviour, IUpdater
    {
        public event Action OnUpdate;
        public event Action<float> OnUpdateWithDelta;
        public event Action OnFixedUpdate;
        public event Action<float> OnFixedUpdateWithDelta;
        public event Action<bool> OnApplicationPauseChanged;
        public event Action OnExit;

        private void Update()
        {
            OnUpdate?.Invoke();
            OnUpdateWithDelta?.Invoke(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
            OnFixedUpdateWithDelta?.Invoke(Time.fixedDeltaTime);
        }

        public void OnApplicationPause(bool isPaused) => OnApplicationPauseChanged?.Invoke(isPaused);

        private void OnDestroy() => OnExit?.Invoke();

        public void ClearAllListeners()
        {
            OnUpdate = null;
            OnFixedUpdate = null;
            OnExit = null;
        }
    }
}