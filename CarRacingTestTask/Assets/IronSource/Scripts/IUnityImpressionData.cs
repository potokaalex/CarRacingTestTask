using System;

namespace IronSourceRoot.IronSource.Scripts
{
    public interface IUnityImpressionData
    {
        event Action<IronSourceImpressionData> OnImpressionDataReady;

        event Action<IronSourceImpressionData> OnImpressionSuccess;
    }
}
