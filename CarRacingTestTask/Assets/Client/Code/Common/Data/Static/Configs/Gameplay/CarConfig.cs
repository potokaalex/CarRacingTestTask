using System.Collections.Generic;
using Client.Code.Gameplay.Game.Car;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Common.Data.Static.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Car", fileName = "CarConfig", order = 0)]
    public class CarConfig : SerializedScriptableObject
    {
        public CarObject Prefab;
        public SpoilerObject SpoilerPrefab;
        public Dictionary<CarColorType, Material> CarColors;

        public float MotorForce;
        public float BrakeForce;
        public float MaxMoveVelocity;

        public float MaxSteerAngle;
        public float SteerAngleAccelerationTimeSec;

        public float MinVelocityToDrift;
        public float MinAngleToDrift;
    }
}