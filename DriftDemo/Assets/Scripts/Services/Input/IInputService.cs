using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    {
        float TreadleInput { get; }
        float SteeringInput { get; }
        bool HandbrakeInput { get; }

        void DisableInput();
    }
}

