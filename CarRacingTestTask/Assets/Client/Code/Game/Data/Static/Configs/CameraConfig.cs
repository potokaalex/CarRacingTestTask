using Client.Code.Game.Gameplay.GameplayCamera;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Code.Game.Data.Static.Configs
{
    [CreateAssetMenu(menuName = "Configs/Game/Camera", fileName = "CameraConfig", order = 0)]
    public class CameraConfig : ScriptableObject
    {
        public CameraObject Prefab;

        [Title("Input")] public float RotationInputSensitivity = 3.5f;
        public float ZoomInputSensitivity;

        [Title("Rotation")] public float MinAngleY = -7;
        public float MaxAngleY = 80;

        [Title("Position")] public float InitialDistanceToTarget = 10;
        public float MinDistanceToTarget = 4;
        public float MaxDistanceToTarget = 10;
        public float ZoomVelocity = 10;
        public float FollowVelocity = 10;
        public Vector3 TargetOffsetRelativeToCameraRotation = new(0, 1.5f, 0.5f);
    }
}