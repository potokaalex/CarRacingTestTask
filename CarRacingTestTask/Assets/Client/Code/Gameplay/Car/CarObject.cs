using Client.Code.Data.Gameplay;
using Client.Code.Gameplay.Wheel;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Gameplay.Car
{
    public class CarObject : SerializedMonoBehaviour
    {
        [Title("Static")] public Rigidbody Rigidbody;
        public Transform CenterOfMass;
        public WheelObject[] WheelObjects;

        [Title("Runtime")] public CarConfig Config;
        public WheelController[] Wheels;
        public bool IsDrift;

        public float MoveDirection;
        public bool IsBrake;
        public float MoveVelocity;
        public Vector3 FlatVelocity;

        public float SteerDirection;
        public float TargetSteerAngle;
        public float CurrentSteerAngle;
    }
}