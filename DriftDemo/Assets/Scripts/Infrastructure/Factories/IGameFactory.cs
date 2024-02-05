using Logic;
using Data;
using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Infrastructure
{
    public interface IGameFactory
    {
        PlayerGarage CreatePlayerGarage(IPlayerDataService playerDataService);
        Currency CreateCurrency();
        ICoroutineRunner CreateCoroutineRunner();
        LoadingCurtain CreateLoadingCurtain();
        List<ISavedProgress> ProgressObjects { get; }
        GameObject CreateAdsPauser();
    }
}

