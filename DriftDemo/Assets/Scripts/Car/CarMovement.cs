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
        [SerializeField] private DriftAnalyzer _analyzer;

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

        private const float MpsToKph = 3.6f;
        public CarStatsSO CarStats => _carStats;


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
            ControlSpeed();
            _hudMediator.ShowSpeed(_rb.velocity.magnitude * MpsToKph);
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

            ApplyDriftingStiffness(_rearLeftCollider);
            ApplyDriftingStiffness(_rearRightCollider);
        }

        private void ApplyDriftingStiffness(WheelCollider wheelCollider)
        {
            wheelCollider.forwardFriction = RecalculateFriction(wheelCollider.forwardFriction);
            wheelCollider.sidewaysFriction = RecalculateFriction(wheelCollider.sidewaysFriction);
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

        private WheelFrictionCurve RecalculateFriction(WheelFrictionCurve curve)
        {
            float velocity = _rb.velocity.magnitude;

            if (_inputService.HandbrakeInput)
                curve.stiffness = Mathf.SmoothDamp(curve.stiffness, _carStats.TargetStiffness, ref velocity, Time.fixedDeltaTime);
            else if (_analyzer.IsDrifting)
                curve.stiffness = Mathf.SmoothDamp(curve.stiffness, .85f, ref velocity, Time.fixedDeltaTime);
            else
                curve.stiffness = 1f;

            return curve;
        }

        private void ControlSpeed()
        {
            if (_rb.velocity.magnitude * MpsToKph > _carStats.MaxSpeed)
                _rb.velocity = (_rb.velocity.normalized * _carStats.MaxSpeed) / MpsToKph;

            if (_inputService.TreadleInput == 0)
            {
                _rb.velocity *= _carStats.NaturalSlowdownPerSecond;
            }
        }
    }
}

