using System;

namespace Client.Code.Services.Updater
{
    public interface IUpdater
    {
        event Action OnUpdate;
        event Action<float> OnUpdateWithDelta;
        event Action OnFixedUpdate;
        event Action<float> OnFixedUpdateWithDelta;
        event Action<bool> OnApplicationPauseChanged;
        event Action OnDispose;
        void ClearAllListeners();
    }
}