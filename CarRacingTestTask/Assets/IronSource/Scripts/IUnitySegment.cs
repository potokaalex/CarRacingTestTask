using System;

namespace IronSourceRoot.IronSource.Scripts
{
    public interface IUnitySegment
    {
        event Action<String> OnSegmentRecieved;
    }
}
