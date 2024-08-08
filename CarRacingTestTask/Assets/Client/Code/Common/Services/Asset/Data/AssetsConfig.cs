using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Code.Common.Services.Asset.Data
{
    [CreateAssetMenu(menuName = "Configs/Project/Assets", fileName = "AssetsConfig", order = 0)]
    public class AssetsConfig : SerializedScriptableObject
    {
        public Dictionary<AssetType, AssetReference> References;
    }
}