﻿using System;

namespace IronSourceRoot.IronSource.Scripts
{
    public interface IUnityLevelPlayRewardedVideoManual
    {
        event Action<IronSourceAdInfo> OnAdReady;

        event Action<IronSourceError> OnAdLoadFailed;
    }
}
