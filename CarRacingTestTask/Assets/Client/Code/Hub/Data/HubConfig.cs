using System.Collections.Generic;
using Client.Code.Common.Services.Asset;
using Client.Code.Common.UI.Windows;
using Client.Code.Hub.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Common.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Hub", fileName = "HubConfig", order = 0)]
    public class HubConfig : SerializedScriptableObject, IAsset
    {
        public Dictionary<WindowType, WindowBase> Windows;
        public HubCanvas CanvasPrefab;
    }
}