using Client.Code.Common.Services.Asset;
using Client.Code.Common.Services.AudioService;
using Client.Code.Common.Services.InputService;
using Client.Code.Common.Services.LoadingScreen.UI;
using Client.Code.Common.Services.SceneLoader.Data;
using Client.Code.Common.Services.Shop.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Common.Data.Configs
{
    [CreateAssetMenu(menuName = "Configs/Project/Main", fileName = "ProjectConfig", order = 0)]
    public class ProjectConfig : SerializedScriptableObject, IAsset
    {
        public ShopConfig Shop;
        public AudioConfig Audio;
        public SceneConfig Scene;
        public InputConfig Input;
        public LoadingScreen LoadingScreenPrefab;
    }
}