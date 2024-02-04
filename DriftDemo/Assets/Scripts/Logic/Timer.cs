using Services.Input;
using UnityEngine;
using Zenject;

namespace Logic
{
    public class Timer : MonoBehaviour
    {
        private HudMediator _mediator;
        private IInputService _inputService;
        [Inject]
        public void Construct(HudMediator hudMediator, IInputService inputService)
        {
            _mediator = hudMediator;
            _inputService = inputService;
            _timer = StartTime;
        }

        private float _timer;
        private const float StartTime = 120f;

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer < 0) 
            {
                _timer = 0;
                _inputService.DisableInput();
                _mediator.ShowFinishPanel();
            }

            _mediator.DisplayTimer(_timer);
        }
    }
}

