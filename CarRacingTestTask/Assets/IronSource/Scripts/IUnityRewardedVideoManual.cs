using System;

namespace IronSourceRoot.IronSource.Scripts
{
    public interface IUnityRewardedVideoManual
    {
        event Action OnRewardedVideoAdReady;

        event Action<IronSourceError> OnRewardedVideoAdLoadFailed;

    }
}