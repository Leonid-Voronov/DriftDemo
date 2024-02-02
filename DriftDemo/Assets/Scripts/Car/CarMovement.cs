using Services.Input;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Car
{
    public class CarMovement : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private CarStatsSO _carStats;
        [SerializeField] private Rigidbody _rb;

        [Header("Wheel transforms")]
        [SerializeField] private Transform _frontLeftTransform;
        [SerializeField] private Transform _frontRightTransform;
        [SerializeField] private Transform _rearLeftTransform;
        [SerializeField] private Transform _rearRightTransform;

        [Header("Wheel colliders")]
        [SerializeField] private WheelCollider _frontLeftCollider;
        [SerializeField] private WheelCollider _frontRightCollider;
        [SerializeField] private WheelCollider _rearLeftCollider;
        [SerializeField] private WheelCollider _rearRightCollider;
        private Dictionary<Transform, WheelCollider> _wheelColliders;
        private IInputService _inputService;
        private HudMediator _hudMediator;

        [Inject]
        public void Construct(IInputService inputService, HudMediator hudMediator)
        {
            _inputService = inputService;
            _hudMediator = hudMediator;
        }

        private void Start()
        {
            _wheelColliders = new Dictionary<Transform, WheelCollider>()
            {
                [_frontLeftTransform] = _frontLeftCollider,
                [_frontRightTransform] = _frontRightCollider,
                [_rearLeftTransform] = _rearLeftCollider,
                [_rearRightTransform] = _rearRightCollider
            };
        }

        private void FixedUpdate()
        {
            HandleMotor();
            HandleSteering();
            UpdateWheels();
            _hudMediator.ShowSpeed(_rb.velocity.magnitude * 3.6f);
        }

        private void HandleMotor()
        {
            ApplyTorqueToWheel(_rearLeftCollider);
            ApplyTorqueToWheel(_rearRightCollider);

            float currentBreakForce = _inputService.HandbrakeInput ? _carStats.BreakForce : 0f; 
            ApplyBreaking(currentBreakForce);
        }

        private void HandleSteering()
        {
            ApplySteeringToWheel(_frontLeftCollider);
            ApplySteeringToWheel(_frontRightCollider);
        }

        private void ApplyBreaking(float breakForce)
        {
            _rearLeftCollider.brakeTorque = breakForce;
            _rearRightCollider.brakeTorque = breakForce;

            ApplyDriftingStifness(_rearLeftCollider);
            ApplyDriftingStifness(_rearRightCollider);
        }

        private void ApplyDriftingStifness(WheelCollider wheelCollider)
        {
            float velocity = _rb.velocity.magnitude;
            WheelFrictionCurve forwardFriction = wheelCollider.forwardFriction;
            forwardFriction.stiffness = _inputService.HandbrakeInput ? Mathf.SmoothDamp(forwardFriction.stiffness, .5f, ref velocity, Time.deltaTime) : 1f;
            wheelCollider.forwardFriction = forwardFriction;

            WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;
            sidewaysFriction.stiffness = _inputService.HandbrakeInput ? Mathf.SmoothDamp(sidewaysFriction.stiffness, .5f, ref velocity, Time.deltaTime) : 1f;
            wheelCollider.sidewaysFriction = sidewaysFriction;
        }

        private void UpdateWheels()
        {
            foreach (var pair in _wheelColliders)
                UpdateWheel(pair.Value, pair.Key);
        }

        private void ApplyTorqueToWheel(WheelCollider wheelCollider) 
            => wheelCollider.motorTorque = _inputService.TreadleInput * _carStats.MotorForce;

        private void ApplySteeringToWheel(WheelCollider wheelCollider) 
            => wheelCollider.steerAngle = _inputService.SteeringInput * _carStats.MaxSteerAngle;

        private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            Vector3 position;
            Quaternion rotation;
            wheelCollider.GetWorldPose(out position, out rotation);
            wheelTransform.position = position;
            wheelTransform.rotation = rotation;
        }
    }
}

