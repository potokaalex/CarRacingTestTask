using UnityEngine;

namespace Client.Code.Gameplay.Wheel
{
    public class WheelObject : MonoBehaviour
    {
        public Transform Mesh;
        public WheelCollider Collider;
        public float BrakeForceRatio;
        public bool IsSteering;
    }
}