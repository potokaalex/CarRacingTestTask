using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Common.Services.InputService
{
    [CreateAssetMenu(menuName = "Configs/Project/Input", fileName = "InputConfig", order = 0)]
    public class InputConfig : SerializedScriptableObject
    {
        public InputObject InputPrefab;
    }
}