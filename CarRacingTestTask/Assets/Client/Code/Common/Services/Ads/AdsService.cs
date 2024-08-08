using Client.Code.Common.Services.Logger.Base;
using Client.Code.Common.Services.Unity;
using Client.Code.Common.Services.Updater;
using IronSourceRoot.IronSource.Scripts;
using UnityEngine;
using Zenject;

namespace Client.Code.Common.Services.Ads
{
    public class AdsService : IInitializable
    {
        private readonly IUpdater _updater;
        private readonly ILogReceiver _logReceiver;

        public AdsService(IUpdater updater, ILogReceiver logReceiver)
        {
            _updater = updater;
            _logReceiver = logReceiver;
        }

        public void Initialize()
        {
            _updater.OnApplicationPauseChanged += isPaused => IronSource.Agent.onApplicationPause(isPaused);
            InitializeIronSource();
        }

        private void InitializeIronSource()
        {
            var settings = Resources.Load<IronSourceMediationSettings>(IronSourceConstants.IRONSOURCE_MEDIATION_SETTING_NAME);
            var appKey = GetAppKey(settings);

            if (settings.EnableIntegrationHelper)
                IronSource.Agent.validateIntegration();

            if (settings.EnableAdapterDebug)
                IronSource.Agent.setAdaptersDebug(true);

            if (appKey.Equals(string.Empty))
                _logReceiver.Log(new LogData { Message = "Cannot init ads without app key." });
            else
            {
                IronSource.Agent.validateIntegration();
                IronSource.Agent.init(appKey);
            }
        }

        private string GetAppKey(IronSourceMediationSettings settings)
        {
            if (PlatformsConstants.IsAndroid)
                return settings.AndroidAppKey;
            if (PlatformsConstants.IsIOS)
                return settings.IOSAppKey;
            return AdsConstants.UndefinedPlatformAppKey;
        }
    }
}