using Client.Code.Services.AssetProvider;
using UnityEngine;

namespace Client.Code.Data.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Gameplay", fileName = "GameplayConfig", order = 0)]
    public class GameplayConfig : ScriptableObject, IAsset
    {
        public CarConfig Car;
    }
}