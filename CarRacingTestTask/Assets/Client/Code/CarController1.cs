using Client.Code.Data.Gameplay;
using Client.Code.Gameplay;
using Client.Code.Gameplay.Wheel;
using Client.Code.Services.AssetProvider;
using UnityEngine;
using Zenject;

namespace Client.Code
{
    public class CarController1 : MonoBehaviour
    {
        [SerializeField] private Transform _centerOfMass;
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private WheelObject[] _wheels;

        [SerializeField] private float _motorForce;
        [SerializeField] private float _brakeForce;
        [SerializeField] private AnimationCurve _steeringCurve;

        private float _currentVelocity;

        private float _brakeInput;

        //private Vector3 _moveDirection; //показывает направление движения.
        private float _horizontalInput;
        private float _moveDirection;
        private bool _isBrake;
        private CarConfig _config;

        private WheelController _wheelController;
        private IAssetProvider<GameplayConfig> _assetProvider;
        private float _currentMoveVelocity;

        [Inject]
        public void Construct(WheelController wheelController, IAssetProvider<GameplayConfig> assetProvider)
        {
            _wheelController = wheelController;
            _assetProvider = assetProvider;
        }

        private void Awake()
        {
            _config = _assetProvider.Get().Car;

            _rigidbody.centerOfMass = _centerOfMass.position;

            
            //      Асфальт:
            //            forwardStiffness: 1.0
            //              sidewaysStiffness: 1.0
//
            //      Гравий:
            //            forwardStiffness: 0.6
            //              sidewaysStiffness: 0.7
//
            //      Грязь:
            //            forwardStiffness: 0.4
            //              sidewaysStiffness: 0.5
//
            //Лед:
            //    forwardStiffness: 0.1
            //    sidewaysStiffness: 0.2
            

            //не реботает!
            //foreach (var wheel in _wheels)
            //    SetFriction(wheel.WheelCollider, 0.6f, 0.7f);
        }



        private void FixedUpdate()
        {
            //Steering();
            //Brake();
        }

        private void Steering()
        {
            var steeringAngle = _horizontalInput * _steeringCurve.Evaluate(_currentVelocity);
            var slipAngle = Vector3.Angle(transform.forward, _rigidbody.velocity - transform.forward);

            if (slipAngle < 120)
                steeringAngle += Vector3.SignedAngle(transform.forward, _rigidbody.velocity, Vector3.up);

            steeringAngle = Mathf.Clamp(steeringAngle, -48, 48);

            //foreach (var wheel in _wheels)
            //    if (wheel.IsForward)
             //       wheel.Collider.steerAngle = steeringAngle;
        }

        private void SetFriction(WheelCollider wheel, float forwardStiffness, float sidewaysStiffness)
        {
            var forwardFriction = wheel.forwardFriction;
            forwardFriction.stiffness = forwardStiffness;
            wheel.forwardFriction = forwardFriction;

            var sidewaysFriction = wheel.sidewaysFriction;
            sidewaysFriction.stiffness = sidewaysStiffness;
            wheel.sidewaysFriction = sidewaysFriction;
        }
    }
}