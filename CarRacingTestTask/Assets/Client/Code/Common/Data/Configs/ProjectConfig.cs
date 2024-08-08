using System.Collections.Generic;
using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.Services.InputService;
using Client.Code.Common.Services.Shop;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Common.Data.Configs
{
    [CreateAssetMenu(menuName = "Configs/Project/Main", fileName = "ProjectConfig", order = 0)]
    public class ProjectConfig : SerializedScriptableObject, IAsset
    {
        public Dictionary<SceneName, string> SceneNames;
        public InputObject InputPrefab;
        public ShopConfig Shop;
        public AudioConfig Audio;
    }
}