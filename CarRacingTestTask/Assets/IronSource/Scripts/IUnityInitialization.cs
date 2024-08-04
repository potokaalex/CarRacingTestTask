using System;

namespace IronSourceRoot.IronSource.Scripts
{
     public interface IUnityInitialization
     {
          event Action OnSdkInitializationCompletedEvent;
     }
}
