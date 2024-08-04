using Client.Code.Gameplay.Data.Static.Configs;
using Client.Code.Gameplay.Game.Wheel;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Gameplay.Game.Car
{
    public class CarObject : SerializedMonoBehaviour
    {
        [Title("Static")] public Rigidbody Rigidbody;
        public Transform CenterOfMass;
        public WheelController[] Wheels;
        public Transform SpoilerSpawnPoint;
        public MeshRenderer Mesh;

        [Title("Runtime")] public CarConfig Config;
        public float MoveDirection;
        public bool IsBrake;
        public float MoveVelocity;

        public float SteerDirection;
        public float TargetSteerAngle;
        public float CurrentSteerAngle;

        public bool IsDrift;
    }
}