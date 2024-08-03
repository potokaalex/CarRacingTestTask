using System;
using UnityEngine;

namespace Client.Code
{
    public class AdsInitializer : MonoBehaviour
    {
        public string Key;

        private void Awake()
        {
            IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
            IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
            IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
            IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
            IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
            IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
            IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;
        }

        private void Start()
        {
            //var appKey = "unexpected_platform";
            UnityEngine.Debug.Log("unity-script: StartInit");
            IronSource.Agent.init(Key);
            IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
        }

        private void SdkInitializationCompletedEvent() => Debug.Log("unity-script: Init ready!");

        private void OnApplicationPause(bool isPaused)
        {
            Debug.Log("unity-script: OnApplicationPause = " + isPaused);
            IronSource.Agent.onApplicationPause(isPaused);
        }

        public void OnGUI()
        {
            GUI.backgroundColor = Color.blue;
            GUI.skin.button.fontSize = (int)(0.035f * Screen.width);

            Rect loadInterstitialButton = new Rect(0.10f * Screen.width, 0.35f * Screen.height, 0.35f * Screen.width, 0.08f * Screen.height);
            if (GUI.Button(loadInterstitialButton, "Load Interstitial"))
            {
                Debug.Log("unity-script: LoadInterstitialButtonClicked");
                IronSource.Agent.loadInterstitial();
            }

            Rect showInterstitialButton = new Rect(0.55f * Screen.width, 0.35f * Screen.height, 0.35f * Screen.width, 0.08f * Screen.height);
            if (GUI.Button(showInterstitialButton, "Show Interstitial"))
            {
                Debug.Log("unity-script: ShowInterstitialButtonClicked");
                if (IronSource.Agent.isInterstitialReady())
                {
                    IronSource.Agent.showInterstitial();
                }
                else
                {
                    Debug.Log("unity-script: IronSource.Agent.isInterstitialReady - False");
                }
            }
        }
        
        void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo) {
            Debug.Log("unity-script: I got InterstitialOnAdReadyEvent With AdInfo " + adInfo.ToString());
        }

        void InterstitialOnAdLoadFailed(IronSourceError ironSourceError) {
            Debug.Log("unity-script: I got InterstitialOnAdLoadFailed With Error " + ironSourceError.ToString());
        }

        void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo) {
            Debug.Log("unity-script: I got InterstitialOnAdOpenedEvent With AdInfo " + adInfo.ToString());
        }

        void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo) {
            Debug.Log("unity-script: I got InterstitialOnAdClickedEvent With AdInfo " + adInfo.ToString());
        }

        void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo) {
            Debug.Log("unity-script: I got InterstitialOnAdShowSucceededEvent With AdInfo " + adInfo.ToString());
        }

        void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo) {
            Debug.Log("unity-script: I got InterstitialOnAdShowFailedEvent With Error " +ironSourceError.ToString()+ " And AdInfo " + adInfo.ToString());
        }

        void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo) {
            Debug.Log("unity-script: I got InterstitialOnAdClosedEvent With AdInfo " + adInfo.ToString());
        }
    }
}