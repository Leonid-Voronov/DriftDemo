using UnityEngine;

namespace Car
{
    [CreateAssetMenu(fileName = "CarStats", menuName = "ScriptableObjects/CarStats", order = 1)]
    public class CarStatsSO : ScriptableObject
    {
        [SerializeField] private float _motorForce;
        [SerializeField] private float _breakForce;
        [SerializeField] private float _maxSteerAngle;
        public float MotorForce => _motorForce;
        public float BreakForce => _breakForce;
        public float MaxSteerAngle => _maxSteerAngle;
    }
}

