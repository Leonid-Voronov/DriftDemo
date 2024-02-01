using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    {
        Vector2 TreadleInput { get; }
        Vector2 SteeringInput { get; }
        bool HandbrakeInput { get; }
    }
}

