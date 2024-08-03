using Client.Code.Services.Updater;
using UnityEngine;
using Zenject;

namespace Client.Code.Services.Ads
{
    public class AdsService : IInitializable
    {
        private readonly IUpdater _updater;

        public AdsService(IUpdater updater) => _updater = updater;

        public void Initialize()
        {
            _updater.OnApplicationPauseChanged += isPaused => IronSource.Agent.onApplicationPause(isPaused);
            IronSourceEvents.onSdkInitializationCompletedEvent += OnInitializationCompleted;

            InitializeIronSource();
        }

        private void OnInitializationCompleted() => Debug.Log("Ads initialization completed."); //TODO: logger

        private static void InitializeIronSource()
        {
            var settings = Resources.Load<IronSourceMediationSettings>(IronSourceConstants.IRONSOURCE_MEDIATION_SETTING_NAME);
            var appKey = GetAppKey(settings);

            if (settings.EnableIntegrationHelper)
                IronSource.Agent.validateIntegration();

            if (settings.EnableAdapterDebug)
                IronSource.Agent.setAdaptersDebug(true);

            if (appKey.Equals(string.Empty))
                Debug.LogWarning("Cannot init ads without AppKey"); //TODO: logger
            else
            {
                IronSource.Agent.validateIntegration();
                IronSource.Agent.init(appKey);
            }
        }

        private static string GetAppKey(IronSourceMediationSettings settings)
        {
#if UNITY_ANDROID
            return settings.AndroidAppKey;
#elif UNITY_IOS
            return settings.IOSAppKey;
#endif
        }
    }
}