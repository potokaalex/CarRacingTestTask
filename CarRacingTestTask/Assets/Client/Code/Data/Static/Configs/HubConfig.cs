using System.Collections.Generic;
using Client.Code.Hub;
using Client.Code.Services.Asset;
using Client.Code.UI.Windows;
using Client.Code.UI.Windows.SelectLevel;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Hub", fileName = "HubConfig", order = 0)]
    public class HubConfig : SerializedScriptableObject, IAsset
    {
        public Dictionary<WindowType, WindowBase> Windows;
        public HubCanvas CanvasPrefab;
    }
}