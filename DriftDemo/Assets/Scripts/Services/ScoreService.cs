using Data;
using System;
using UnityEngine;
using Zenject;

namespace Services
{
    public class ScoreService : IScoreService, IDisposable, IInitializable
    {
        private HudMediator _mediator;
        private float _sessionScore = 0f;
        private float _currentScore = 0f;
        private Currency _currency;
        private IAdsService _adsService;

        [Inject]
        public ScoreService(HudMediator mediator, IPlayerDataService playerDataService, IAdsService adsService)
        {
            _mediator = mediator;
            _currency = playerDataService.Currency;
            _adsService = adsService;
        }

        public float SessionScore => _sessionScore;
        public void Initialize() => _mediator.DoubleRewardButtonPressed += DoubleReward;
        public void AddScore(float delta)
        {
            _sessionScore += delta;
            _currentScore += delta;
            _mediator.DisplayCurrentScore(_currentScore);
            _mediator.DisplaySessionScore(_sessionScore);
        }

        public void ConvertScoreToCash() => _currency.AddCash(_sessionScore);

        public void Dispose()
        {
            ConvertScoreToCash();
            _mediator.DoubleRewardButtonPressed -= DoubleReward;
        }

        public void ResetCurrentScore() => _currentScore = 0f;

        private void DoubleReward(object sender, EventArgs e)
        {
            _adsService.ShowRewardedVideo();
            _sessionScore *= 2;
        }
    }
}

