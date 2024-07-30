using System;
using Client.Code.Gameplay.Car;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Client.Code.Data.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Car", fileName = "CarConfig", order = 0)]
    public class CarConfig : SerializedScriptableObject
    {
        public CarObject Prefab;
        public float MotorForce;
        public float BrakeForce;
    }
}