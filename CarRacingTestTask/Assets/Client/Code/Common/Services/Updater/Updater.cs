using System;
using UnityEngine;

namespace Client.Code.Common.Services.Updater
{
    public class Updater : MonoBehaviour, IUpdater, IDisposable
    {
        public event Action OnUpdate;
        public event Action<float> OnUpdateWithDelta;
        public event Action OnFixedUpdate;
        public event Action<float> OnFixedUpdateWithDelta;
        public event Action<bool> OnApplicationPauseChanged;
        public event Action OnDispose;

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

        public void Dispose() => OnDispose?.Invoke();

        public void ClearAllListeners()
        {
            OnUpdate = null;
            OnFixedUpdate = null;
            OnDispose = null;
        }
    }
}