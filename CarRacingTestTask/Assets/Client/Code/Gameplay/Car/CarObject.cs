using Client.Code.Gameplay.Wheel;
using UnityEngine;

namespace Client.Code.Gameplay.Car
{
    public class CarObject : MonoBehaviour
    {
        //static
        public Rigidbody Rigidbody;
        public Transform CenterOfMass;
        public WheelObject[] WheelObjects;

        //runtime
        public WheelController[] Wheels;
    }
}