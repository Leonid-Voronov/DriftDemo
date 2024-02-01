using UnityEngine;
using Logic;

namespace Infrastructure
{
    public interface IGameFactory
    {
        ICoroutineRunner CreateCoroutineRunner();
        LoadingCurtain CreateLoadingCurtain();
        GameObject CreateCar();
    }
}

