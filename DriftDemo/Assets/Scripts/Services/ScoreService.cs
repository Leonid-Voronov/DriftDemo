using Data;
using System;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ScoreService : IScoreService, IDisposable
    {
        private HudMediator _mediator;
        private float _sessionScore = 0f;
        private float _currentScore = 0f;
        private Currency _currency;

        [Inject]
        public ScoreService(HudMediator mediator, IPlayerDataService playerDataService)
        {
            _mediator = mediator;
            _currency = playerDataService.Currency;
        }

        public float SessionScore => _sessionScore;

        public void AddScore(float delta)
        {
            _sessionScore += delta;
            _currentScore += delta;
            _mediator.DisplayCurrentScore(_currentScore);
            _mediator.DisplaySessionScore(_sessionScore);
        }

        public void ConvertScoreToCash() => _currency.AddCash(_sessionScore);

        public void Dispose() => ConvertScoreToCash();

        public void ResetCurrentScore() => _currentScore = 0f;

    }
}

