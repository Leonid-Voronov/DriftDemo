using System.Collections;
using UnityEngine;
using Zenject;

namespace Car
{
    public class DriftAnalyzer : MonoBehaviour
    {
        [Header ("Links")]
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private CarMovement _carMovement;
        private HudMediator _hudMediator;
        private CarStatsSO _carStats;
        private float _sessionScore = 0f;
        private float _currentScore = 0f;
        private float _currentDriftAngle = 0f;
        private bool _drifting = false;
        private float _driftScorePerSecond = 1f;

        private const float MaxDriftAngle = 120f;
        public bool IsDrifting => _drifting;

        [Inject]
        public void Construct(HudMediator hudMediator)
        {
            _hudMediator = hudMediator;
        }

        private void OnEnable() => _carStats = _carMovement.CarStats;

        private void Update()
        {
            AnalyzeDrifting();
        }

        private void AnalyzeDrifting()
        {
            float speed = _rb.velocity.magnitude;
            float driftAngle = Vector3.Angle(_rb.transform.forward, (_rb.velocity + _rb.transform.forward).normalized);

            if (driftAngle > MaxDriftAngle)
                driftAngle = 0f;

            if (driftAngle >= _carStats.MinimumDriftAngle && speed > _carStats.MinimumDriftSpeed)
            {
                if (!_drifting)
                {
                    StartCoroutine(StartDriftCoroutine());
                }
            }  
            else if (_drifting)
            {
                StopDriftCounting();
            }

            if (_drifting)
            {
                float scoreDelta = Time.deltaTime * driftAngle * _driftScorePerSecond;
                _currentScore += scoreDelta;
                _driftScorePerSecond += Time.deltaTime;
                _sessionScore += scoreDelta;
                _hudMediator.DisplayCurrentScore(_currentScore);
                _hudMediator.DisplaySessionScore(_sessionScore);
            }
        }

        private IEnumerator StartDriftCoroutine()
        {
            yield return new WaitForSeconds(_carStats.DriftDelay);
            _drifting = true;
            _hudMediator.ShowDriftPanel();
        }

        public void StopDriftCounting()
        {
            _currentScore = 0f;
            _drifting = false;
            _hudMediator.HideDriftPanel();
        }

    }
}

