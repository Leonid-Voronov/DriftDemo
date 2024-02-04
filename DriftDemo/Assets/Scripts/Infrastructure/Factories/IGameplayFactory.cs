using UnityEngine;
using Logic;

namespace Infrastructure
{
    public interface IGameplayFactory
    {
        GameObject CreateCar();
        Timer CreateTimer();
    }
}