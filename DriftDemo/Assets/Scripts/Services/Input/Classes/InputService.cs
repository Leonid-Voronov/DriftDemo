using System;
using UnityEngine;

namespace Services.Input
{
    public class InputService : IInputService
    {
        private PlayerInput _inputActions;

        public InputService(PlayerInput inputActions)
        {
            _inputActions = inputActions;
        }

        public Vector2 TreadleInput => throw new System.NotImplementedException();

        public Vector2 SteeringInput => throw new System.NotImplementedException();

        public bool HandbrakeInput => throw new System.NotImplementedException();
    }
}

