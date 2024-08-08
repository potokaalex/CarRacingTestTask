using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Code.Common.Services.SceneLoader.Data
{
    [CreateAssetMenu(menuName = "Configs/Project/Scene", fileName = "SceneConfig", order = 0)]
    public class SceneConfig : SerializedScriptableObject
    {
        public Dictionary<SceneName, AssetReference> Keys;
    }
}