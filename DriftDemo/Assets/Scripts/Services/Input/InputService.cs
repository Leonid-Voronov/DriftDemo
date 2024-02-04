using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Services.Input
{
    public class InputService : IInputService, IInitializable, IDisposable
    {
        private PlayerInput _inputActions;
        private float _treadleInput;
        private float _steeringInput;
        private bool _handbrakeInput;

        [Inject]
        public InputService(PlayerInput inputActions)
        {
            _inputActions = inputActions;
        }

        public float TreadleInput => _treadleInput;
        public float SteeringInput => _steeringInput;
        public bool HandbrakeInput => _handbrakeInput;
        public void Initialize()
        {
            _inputActions.Enable();
            PlayerInput.GameplayActionMapActions actionMap = _inputActions.GameplayActionMap;
            actionMap.MotorControl.performed += OnMotorControlPerformed;
            actionMap.MotorControl.canceled += OnMotorControlCancelled;
            actionMap.Steering.performed += OnSteeringPerformed;
            actionMap.Steering.canceled += OnSteeringCancelled;
            actionMap.HandBrake.performed += OnHandbrakePerformed;
            actionMap.HandBrake.canceled += OnHandbrakeCancelled;
        }
        public void Dispose() => DisableInput();

        private void OnMotorControlPerformed(InputAction.CallbackContext callbackContext) 
            => _treadleInput = callbackContext.ReadValue<float>();

        private void OnMotorControlCancelled(InputAction.CallbackContext callbackContext) 
            => _treadleInput = 0f;

        private void OnSteeringPerformed(InputAction.CallbackContext callbackContext) 
            => _steeringInput = callbackContext.ReadValue<float>();

        private void OnSteeringCancelled(InputAction.CallbackContext callbackContext) 
            => _steeringInput = 0f;

        private void OnHandbrakePerformed(InputAction.CallbackContext callbackContext)
            => _handbrakeInput = true;

        private void OnHandbrakeCancelled(InputAction.CallbackContext callbackContext)
            => _handbrakeInput = false;

        public void DisableInput()
        {
            _inputActions.Disable();
            PlayerInput.GameplayActionMapActions actionMap = _inputActions.GameplayActionMap;
            actionMap.MotorControl.performed -= OnMotorControlPerformed;
            actionMap.MotorControl.canceled -= OnMotorControlCancelled;
            actionMap.Steering.performed -= OnSteeringPerformed;
            actionMap.Steering.canceled -= OnSteeringCancelled;
            actionMap.HandBrake.performed -= OnHandbrakePerformed;
            actionMap.HandBrake.canceled -= OnHandbrakeCancelled;
        }
    }
}

