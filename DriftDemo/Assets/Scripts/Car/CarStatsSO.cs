using UnityEngine;

namespace Car
{
    [CreateAssetMenu(fileName = "CarStats", menuName = "ScriptableObjects/CarStats", order = 1)]
    public class CarStatsSO : ScriptableObject
    {
        [SerializeField] private float _motorForce;
        [SerializeField] private float _breakForce;
        [SerializeField] private float _maxSteerAngle;
        [SerializeField] private float _maxSpeed;

        [Header("Drift values")]
        [SerializeField] private float _minimumDriftAngle;
        [SerializeField] private float _minimumDriftSpeed;
        [SerializeField] private float _driftDelay;
        public float MotorForce => _motorForce;
        public float BreakForce => _breakForce;
        public float MaxSteerAngle => _maxSteerAngle;
        public float MaxSpeed => _maxSpeed;
        public float MinimumDriftAngle => _minimumDriftAngle;
        public float MinimumDriftSpeed => _minimumDriftSpeed;
        public float DriftDelay => _driftDelay;

    }
}

