using System.Collections.Generic;
using Client.Code.Common.Data;
using Client.Code.Game.Gameplay.Car;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Game.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Game/Car", fileName = "CarConfig", order = 0)]
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