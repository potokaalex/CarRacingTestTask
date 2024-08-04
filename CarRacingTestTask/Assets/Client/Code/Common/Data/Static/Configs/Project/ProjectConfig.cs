using System.Collections.Generic;
using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.InputService;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Common.Data.Static.Configs.Project
{
    [CreateAssetMenu(menuName = "Configs/Project", fileName = "ProjectConfig", order = 0)]
    public class ProjectConfig : SerializedScriptableObject, IAsset
    {
        public Dictionary<SceneName, string> SceneNames;
        public InputObject InputPrefab;
        public ShopConfig Shop;
        public AudioConfig Audio;
    }
}