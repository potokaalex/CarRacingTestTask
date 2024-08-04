﻿using System;

namespace IronSourceRoot.IronSource.Scripts
{
    public interface IUnityLevelPlayBanner
    {
        event Action<IronSourceAdInfo> OnAdLoaded;

        event Action<IronSourceAdInfo> OnAdLeftApplication;

        event Action<IronSourceAdInfo> OnAdScreenDismissed;

        event Action<IronSourceAdInfo> OnAdScreenPresented;

        event Action<IronSourceAdInfo> OnAdClicked;

        event Action<IronSourceError> OnAdLoadFailed;
    }
}
